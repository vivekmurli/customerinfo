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
    class dotProduct
    {

        public static void execute()
        {
            int[] vec1 = new int[16];
            int[] vec2 = new int[16];
            int nblocks = 2;
            int nthreads = 3;
            int[] dot = new int[nblocks];
            for (int i = 0; i < 16; i++)
            {
                vec1[i] = 1;
                vec2[i] = 2;
            }

            CudafyModule km=CudafyTranslator.Cudafy();
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target,CudafyModes.DeviceId);

            Console.WriteLine("Start");
            foreach (GPGPUProperties prop in CudafyHost.GetDeviceProperties(eGPUType.OpenCL, false))
            {
                Console.WriteLine("" + prop.MaxThreadsPerBlock + prop.DeviceId);
            }
         /*   gpu.LoadModule(km);

            int[] dev_vec1 = gpu.CopyToDevice(vec1);
            int[] dev_vec2 = gpu.CopyToDevice(vec2);
            int[] dev_dot = gpu.Allocate<int>(dot);

            Console.WriteLine("Started");
            gpu.Launch(nblocks, nthreads).Product(dev_vec1,dev_vec2,dev_dot);
            gpu.CopyFromDevice(dev_dot,dot);
            int sum=0;
            for (int i = 0; i < nblocks; i++)
            {
                sum = sum + dot[i];
            }
            Console.WriteLine("Dot Product" + sum);
            Console.Read();*/
        }

        [Cudafy]
        public static void Product(GThread thread, int[] a, int[] b, int[] c)
        {
            int tid = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;
            int[] cache = thread.AllocateShared<int>("cache", 4);
            int temp = 0;
            int cacheIndex=thread.threadIdx.x;
            while (tid < 16)
            {
                temp = temp + a[tid] * b[tid];
                tid += thread.blockDim.x * thread.gridDim.x;
            }
            cache[thread.threadIdx.x] = temp;

            thread.SyncThreads();

            int i = thread.blockDim.x / 2;
            while (i != 0)
            {
                if (cacheIndex < i)
                {
                    cache[cacheIndex] += cache[cacheIndex + i];
                }
                thread.SyncThreads();

                i /= 2;
            }
            if (cacheIndex == 0)
            {
                c[thread.blockIdx.x] = cache[0];
            }
        }

    }
}
