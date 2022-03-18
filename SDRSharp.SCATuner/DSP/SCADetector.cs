using SDRSharp.Radio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRSharp.SCATuner
{
    class SCADetector
    {
        //Transfiltered
        private UnsafeBuffer _rawFilteredBuffer;
        private unsafe Complex* _rawFilteredPtr;

        //Audio goes here
        private UnsafeBuffer _AudioBuffer;
        private unsafe float* _AudioPtr;

        private double _sampleRate;

        //Filter
        private IQFirFilter _baseBandFilter;
        private DownConverter _downConverter;

        //FM Demodulator
        SDRSharp.Radio.FmDetector fm = new FmDetector();

        /// <summary>
        /// Whenever you call me,
        /// I will take your buffer of samples,
        /// sprinckle some magic dust over it 
        /// and fill your empty buffer with it
        /// </summary>
        /// <param name="baseBand">Buffer you want to modify</param>
        /// <param name="audio">Empty buffer I will fill</param>
        /// <param name="length">length of the first buffer so I know where it ends</param>
        public unsafe void Process(float* baseBand, float* audio, int length)
        {
            #region Initialize buffers
            if (this._rawFilteredBuffer == null || this._rawFilteredBuffer.Length != length)
            {
                this._rawFilteredBuffer = UnsafeBuffer.Create(length, sizeof(Complex));
                this._rawFilteredPtr = (Complex*)(void*)this._rawFilteredBuffer;
            }
            if (_AudioBuffer == null || _AudioBuffer.Length != length)
            {
                _AudioBuffer = UnsafeBuffer.Create(length, sizeof(float));
                _AudioPtr = (float*)_AudioBuffer;
            }
            #endregion

            // Downconvert
            DSPUtils.RealToComplex(baseBand, _rawFilteredPtr, length);
            _downConverter.Process(_rawFilteredPtr, length);

            // Filter
            _baseBandFilter.Process(_rawFilteredPtr, length);

            //Demodulate
            fm.Demodulate(_rawFilteredPtr, audio, length);
        }
        /// <summary>
        /// This method is used when we want to change configuration in real time
        /// </summary>
        /// <param name="frequency"></param>
        public void reConfigure(double frequency)
        {
            _downConverter.Frequency = frequency;
        }

        /// <summary>
        /// This method will configure our detector
        /// </summary>
        /// <param name="sampleRate"></param>
        public unsafe void Configure(double sampleRate)
        {
            this._sampleRate = sampleRate;

            _downConverter = new DownConverter(sampleRate, 1);
            _downConverter.Frequency = 67000;


            var coefficients = FilterBuilder.MakeLowPassKernel(sampleRate, 250, 7e3, WindowType.BlackmanHarris4);
            _baseBandFilter = new IQFirFilter(coefficients, 1);

            this.fm.SampleRate = sampleRate;
            this.fm.Mode = FmMode.Wide;
        }
    }
}
