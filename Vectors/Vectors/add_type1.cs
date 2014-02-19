using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;
using System.Diagnostics;

namespace Vectors
{
    class add_type1
    {
        public const int N = 10000000;

        public static void execute()
        {
            int[] a = new int[N];
            int[] b = new int[N];
            int[] c = new int[N];
            int[] d = new int[N];
            int[] e = new int[N];
            int[] sum = new int[N];

            Stopwatch stp = new Stopwatch();
            //Initialising Arrays
            for (int i = 0; i < N; i++)
            {
                a[i] = i;
                b[i] = i + 2;
                c[i] = i;
                d[i] = i + 2;
                e[i] = i;
            }

            Console.WriteLine("Adding 5 vectors of size 10000000");
            CudafyModule km = CudafyTranslator.Cudafy();
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);

            stp.Start();

            int[] dev_a = gpu.CopyToDevice(a);
            int[] dev_b = gpu.CopyToDevice(b);
            int[] dev_c = gpu.CopyToDevice(c);
            int[] dev_d = gpu.CopyToDevice(c);
            int[] dev_e = gpu.CopyToDevice(c);
            int[] dev_sum = gpu.Allocate<int>(sum);
            gpu.LoadModule(km);

            //Launch 100 blocks each block having 100 threads
            gpu.Launch(100, 100).add(dev_a, dev_b, dev_c, dev_d, dev_e, dev_sum);
            gpu.CopyFromDevice(dev_sum, sum);
            stp.Stop();
            Console.WriteLine("Time in Milliseconds : " + stp.ElapsedMilliseconds);

        }

        [Cudafy]
        public static void add(GThread thread, int[] a, int[] b, int[] c, int[] d, int[] e, int[] sum)
        {
            //To get Array Index for each Thread
            int index = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;

            while (index < N)
            {
                sum[index] = a[index] + b[index] + c[index] + d[index] + e[index];
                index = index + thread.blockDim.x * thread.gridDim.x;
            }
        }
    }
}
