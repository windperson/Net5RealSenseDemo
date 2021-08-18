using Intel.RealSense;
using System;

namespace Net5RealSenseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start RealSense camera...\r\n");

            var pipe = new Pipeline();
            pipe.Start();

            while (true)
            {
                using (var frames = pipe.WaitForFrames())
                using (var depth = frames.DepthFrame)
                {
                    Console.WriteLine($"The camera is pointing at: {depth.GetDistance(depth.Width / 2, depth.Height / 2):00.0000} meter(s) away.");

                    Console.SetCursorPosition(0, 2);
                }
            }
        }
    }
}
