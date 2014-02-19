
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            //To Run on Emulator
             CudafyModes.Target = eGPUType.Emulator;
            CudafyModes.DeviceId = 0;
            CudafyTranslator.Language = CudafyModes.Target == eGPUType.Emulator ? eLanguage.OpenCL : eLanguage.Cuda;

            //To Run on GPU
          /*  CudafyModes.Target = eGPUType.OpenCL;
            CudafyModes.DeviceId = 0;
            CudafyTranslator.Language = CudafyModes.Target == eGPUType.OpenCL ? eLanguage.OpenCL : eLanguage.Cuda;*/

            //add_type1.execute();
            //add_type2.execute();
            dotProduct.execute();
        }
    }
}
