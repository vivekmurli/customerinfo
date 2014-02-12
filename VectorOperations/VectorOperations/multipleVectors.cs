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
    class multipleVectors
    {
        public const int N = 1000;

        public static void execute()
        {
            int[] a = new int[N];
            int[] b = new int[N];
            int[] c = new int[N];
            int count = 0;

            //Console.WriteLine("Vectors assigned");
            CudafyModule km = CudafyTranslator.Cudafy();
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
            int[] dev_a = gpu.Allocate<int>(a);
            int[] dev_b = gpu.Allocate<int>(b);
            int[] dev_c = gpu.Allocate<int>(c);
            gpu.LoadModule(km);

            while (count < N)
            {
                for (int i = 0; i < N; i++)
                {
                    a[i] = i;
                    b[i] = i + 2;
                }
                gpu.CopyToDevice(a, dev_a);
                gpu.CopyToDevice(b, dev_b);
                gpu.Launch(128, 1).add(dev_a, dev_b, dev_c);
                gpu.CopyFromDevice(dev_c, c);
                count++;
            }
            Console.WriteLine("Exeution Completed");
        }

        [Cudafy]
        public static void add(GThread thread, int[] a, int[] b, int[] c)
        {
            int tid = thread.blockIdx.x;
            while (tid < N)
            {
                c[tid] = a[tid] + b[tid];
                tid = tid + thread.gridDim.x;
            }
        }
    }
}
