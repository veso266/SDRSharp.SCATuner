using SDRSharp.Radio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRSharp.SCATuner
{
    class DSPUtils
    {
        public unsafe static void RealToComplex(float* in_buffer, Complex* out_buffer, int length)
        {
            for (int i = 0; i < length; i++)
            {
                out_buffer[i].Real = in_buffer[i];
                out_buffer[i].Imag = 0f;
            }
        }
        public unsafe static void ComplexToReal(Complex* in_buffer, float* out_buffer, int length)
        {
            for (int i = 0; i < length; i++)
            {
                out_buffer[i] = in_buffer[i].Real;
            }
        }
        public unsafe static void ComplexToRealFast(Complex* in_buffer, float* out_buffer, int length)
        {
            Utils.Memcpy(out_buffer, in_buffer, length * 4);
        }
    }
}
