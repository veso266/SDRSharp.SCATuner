using System;
using System.Diagnostics;
using SDRSharp.Common;
using SDRSharp.Radio;
using SDRSharp.Radio.PortAudio;

namespace SDRSharp.SCATuner
{
    public class AudioPlayer
    {

        public int DeviceIndex
        {
            set
            {
                this._deviceIndex = value;
            }
        }

        public float Gain
        {
            set
            {
                this._gain = value;
            }
        }

        public int LostBuffers
        {
            get
            {
                return this._lostBuffers;
            }
        }

        public int BufferSize
        {
            get
            {
                return this._bufferSize;
            }
        }

        public double frequency, lcutoff, hcutoff;
        public void FilterConfigure(double frequency)
        {
            this.frequency = frequency;
        }

        private const float OutputLatency = 0.1f;
        private FloatFifoStream _audioStream;
        private AudioProcessor _audioProcessor;
        private WavePlayer _wavePlayer;
        private Resampler _resampler;
        private UnsafeBuffer _InputBuffer;
        private unsafe float* _InputBufferPtr;
        private int _deviceIndex;
        private double _sampleRateOut;
        private int _outputLength;
        private float _gain;
        private int _lostBuffers;
        private int _bufferSize;
        private int _maxBufferSize;
        private double _sampleRate;
        private int _inputLength;
        
        //Audio out
        private UnsafeBuffer audioBuffer;
        private unsafe float* audioBufferPtr;

        //SCA
        SCADetector sca = new SCADetector();

        //SDRSharpControl
        ISharpControl control;

        public unsafe AudioPlayer(ISharpControl control, AudioProcessor audioProcessor)
        {
            this.control = control;
            this._audioProcessor = audioProcessor;
            this._audioProcessor.AudioReady += this.AudioSamplesIn;
            this._audioProcessor.Enabled = false;
        }

        public void Start()
        {
            this._lostBuffers = 0;
            this._audioStream = new FloatFifoStream(BlockMode.None);
            this._audioProcessor.Enabled = true;
        }

        public unsafe void Stop()
        {
            this._audioProcessor.Enabled = false;
            if (this._wavePlayer != null)
            {
                this._wavePlayer.Dispose();
                this._wavePlayer = null;
            }
            if (this._audioStream != null)
            {
                this._audioStream.Close();
                this._audioStream = null;
            }
            if (this._resampler != null)
            {
                this._resampler = null;
                this.audioBuffer.Dispose();
                this.audioBuffer = null;
                this.audioBufferPtr = null;
                this._InputBuffer.Dispose();
                this._InputBuffer = null;
                this._InputBufferPtr = null;
            }
            this._sampleRate = 0.0;
            this._sampleRateOut = 0.0;
            this._bufferSize = 0;
        }

        private unsafe void AudioSamplesIn(float* buffer, double samplerate, int length)
        {
            if (this._wavePlayer == null || samplerate != this._sampleRate)
            {
                if (samplerate <= 0.0 || samplerate > 400000.0)
                {
                    return;
                }
                this._sampleRate = samplerate;
                this._sampleRateOut = this.control.AudioSampleRate;
                this._maxBufferSize = (int)this._sampleRate;


                //We multiplay our Length by 0.1 so audio device doesn't run out of samples (hear silence when that happens)
                this._inputLength = (int)(this._sampleRate*0.1);
                this._outputLength = (int)(this._sampleRateOut*0.1);

                #region Initialize buffers
                //Input buffer
                if (this._InputBuffer == null || this._InputBuffer.Length != length)
                {
                    this._InputBuffer = UnsafeBuffer.Create(this._inputLength, sizeof(float));
                    this._InputBufferPtr = (float*)this._InputBuffer;
                }
                //Audio
                if (this.audioBuffer == null || this.audioBuffer.Length != length)
                {
                    audioBuffer = UnsafeBuffer.Create(this._inputLength, sizeof(float));
                    this.audioBufferPtr = (float*)audioBuffer;
                }
                #endregion 

                //Configure Subsidiary communications authority
                sca.Configure(samplerate);

                //Configure resampler
                this._resampler = new Resampler(this._sampleRate, this._sampleRateOut);


                if (this._wavePlayer != null)
                {
                    this._wavePlayer.Dispose();
                    this._wavePlayer = null;
                }
                this._wavePlayer = new WavePlayer(this._deviceIndex, this._sampleRateOut, this._outputLength, new AudioBufferNeededDelegate(this.PlayerProcess));
            }
            if (this._audioStream.Length >= this._maxBufferSize)
            {
                this._lostBuffers++;
                return;
            }

            this._audioStream.Write(buffer, length); //Send stream to audio device
            
            
        }

        private unsafe void PlayerProcess(float* buffer, int length)
        {
            if (this._audioStream == null)
            {
                return;
            }
            this._bufferSize = (int)Math.Min((float)this._audioStream.Length / (float)this._maxBufferSize * 100f, 100f);
            if (this._audioStream.Length < this._inputLength)
            {
                this._lostBuffers++;
                for (int i = 0; i < length; i++)
                {
                    buffer[i] = 0f;
                }
                return;
            }

            //Change Subsidiary communications authority frequency
            sca.reConfigure(this.frequency);

            //Read the audiostream into InputBufferPtr (InputBufferPtr holds our audio direcly from SDR#)
            this._audioStream.Read(this._InputBufferPtr, this._inputLength);

            //Process Subsidiary communications authority
            sca.Process(this._InputBufferPtr, this.audioBufferPtr, this._inputLength);

            //Resample to 48khz
            this._resampler.Process(this.audioBufferPtr, buffer, this._inputLength);

            //Boost output 
            this.BoostOutput(buffer, this._outputLength);

        }

        private unsafe void BoostOutput(float* buffer, int length)
        {
            int start = (length - 1) * 2;
            for (int i = length - 1; i >= 0; i--)
            {
                buffer[start] = (buffer[start + 1] = buffer[i] * this._gain * 2);
                start -= 2;
            }
        }
    }
}
