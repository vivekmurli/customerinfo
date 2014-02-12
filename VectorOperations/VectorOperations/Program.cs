
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;

namespace VectorOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            CudafyModes.Target = eGPUType.Emulator;
            //CudafyModes.Target = eGPUType.OpenCL;
            CudafyModes.DeviceId = 0;
            CudafyTranslator.Language = CudafyModes.Target == eGPUType.Emulator ? eLanguage.OpenCL : eLanguage.Cuda;
            //CudafyTranslator.Language = CudafyModes.Target == eGPUType.OpenCL ? eLanguage.OpenCL : eLanguage.Cuda;
            Console.WriteLine("Adding 2 vectors having 100000 values");
            addition.execute();
            Console.WriteLine("Adding 1000 vectors having 1000 values");
            multipleVectors.execute();
        }
    }
}
