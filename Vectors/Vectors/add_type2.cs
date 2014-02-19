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
    class add_type2
    {
        public const int N = 1000;

        public static void execute()
        {
            int[] a = new int[N];
            int[] b = new int[N];
            int[] sum = new int[N];
            int count = 0;
            Stopwatch stp = new Stopwatch();

            CudafyModule km = CudafyTranslator.Cudafy();
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);

            Console.WriteLine("\nAdding 1000 vectors of size 1000");

            stp.Start();

            int[] dev_a = gpu.Allocate<int>(a);
            int[] dev_b = gpu.Allocate<int>(b);
            int[] dev_sum = gpu.Allocate<int>(sum);
            gpu.LoadModule(km);

            while (count < 500)
            {
                for (int i = 0; i < N; i++)
                {
                    a[i] = i;
                    b[i] = i + 2;
                }
                gpu.CopyToDevice(a, dev_a);
                gpu.CopyToDevice(b, dev_b);
                gpu.CopyToDevice(sum, dev_sum);
                gpu.Launch(100, 10).add(dev_a, dev_b, dev_sum);
                gpu.CopyFromDevice(dev_sum, sum);
                count++;
            }
            stp.Stop();
            Console.WriteLine("Time in Milliseconds : " + stp.ElapsedMilliseconds);
            Console.Read();
        }

        [Cudafy]
        public static void add(GThread thread, int[] a, int[] b, int[] sum)
        {
            int index = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;
            while (index < N)
            {
                sum[index] = sum[index] + a[index] + b[index];
                index = index + thread.blockDim.x * thread.gridDim.x;
            }
        }
    }
}
