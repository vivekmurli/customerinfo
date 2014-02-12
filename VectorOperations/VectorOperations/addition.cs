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
    class addition
    {
        public const int N = 100000;

        public static void execute()
        {
            int[] a = new int[N];
            int[] b = new int[N];
            int[] c = new int[N];

            for (int i = 0; i < N; i++)
            {
                a[i] = i;
                b[i] = i + 2;
            }
            Console.WriteLine("Vectors assigned");
            CudafyModule km = CudafyTranslator.Cudafy();
            GPGPU gpu=CudafyHost.GetDevice(CudafyModes.Target,CudafyModes.DeviceId);
            int[] dev_a = gpu.CopyToDevice(a);
            int[] dev_b = gpu.CopyToDevice(b);
            int[] dev_c = gpu.CopyToDevice(c);
            gpu.LoadModule(km);
            gpu.Launch(100,100).add(dev_a,dev_b,dev_c);
            gpu.CopyFromDevice(dev_c, c);

            for (int i = 99990; i < 100000; i++)
            {
                Console.WriteLine(a[i]+"\t"+b[i]);
            }
            Console.WriteLine("\n");
            for(int i=99990;i<100000;i++)
            {
                Console.WriteLine(c[i]);
            }
        }

        [Cudafy]
        public static void add(GThread thread,int[] a,int[] b,int[] c)
        {
            int tid = thread.blockIdx.x + thread.threadIdx.x * thread.blockDim.x;
            while (tid < N)
            {
                c[tid] = a[tid] + b[tid];
                tid = tid + thread.blockDim.x * thread.gridDim.x;
            }
        }
    }
}
