using System;
using SDRSharp.Radio;

namespace SDRSharp.SCATuner
{
    public class AudioProcessor : IRealProcessor, IStreamProcessor, IBaseProcessor
    {

        public event AudioProcessor.AudioReadyDelegate AudioReady;

        public double SampleRate
        {
            get
            {
                return this._sampleRate;
            }
            set
            {
                this._sampleRate = value;
            }
        }


        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        public unsafe void Process(float* buffer, int length)
        {
            AudioProcessor.AudioReadyDelegate audioReady = this.AudioReady;
            if (audioReady != null)
            {
                audioReady(buffer, this._sampleRate, length);
            }
        }

        private double _sampleRate;
        private bool _enabled;
        public unsafe delegate void AudioReadyDelegate(float* audio, double samplerate, int length);
    }
}
