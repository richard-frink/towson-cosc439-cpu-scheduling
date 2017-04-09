using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduling
{
    class Client
    {
        static void Main(string[] args)
        {
            // This is the processes array we will pass to the scheduler
            Tuple<int, int, int>[] p;

            // Get user to say if they want to read from a file or want to input a number of processes for scheduler to generate
            // 1 give the scheduler a randomized list of tuples
            // 2 give scheduler a list of strings from the file

            int opt = getInput();
            if(opt == 1)
            {
                p = getRand();
            }
            else
            {
                string[] processes = System.IO.File.ReadAllLines(@"processes.txt");
                p = getProcessList(processes);
            }

            // Make and kick off scheduler
            Scheduler FCFS_Scheduler = new Scheduler(p);
            FCFS_Scheduler.run();

            Console.ReadLine();
        }

        public static int getInput()
        {
            int num;
            while (true)
            {
                Console.Write("Enter '1' to read from a file, or '2' to generate a random list of processes: ");
                string output = Console.ReadLine();

                if(int.Parse(output) == 1 || int.Parse(output) == 2)
                {
                    num = int.Parse(output);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            return num;
        }

        public static Tuple<int, int, int>[] getProcessList(string[] processes)
        {
            Tuple<int, int, int>[] output = new Tuple<int, int, int>[processes.Length / 3];

            for (int i = 0; i < processes.Length; i++)
            {
                Tuple<int, int, int> j = new Tuple<int, int, int>(int.Parse(processes[i * 3]), int.Parse(processes[i * 3 + 1]), int.Parse(processes[i * 3 + 2]));
                output[i] = j;
            }

            return output;
        }

        public static Tuple<int, int, int>[] getRand()
        {
            Random rand = new Random();

            Tuple<int, int, int>[] output = new Tuple<int, int, int>[rand.Next(3,15)]; // Random number of processes from 3 to 15

            for(int i = 0; i < output.Length; i++)
            {
                Tuple<int, int, int> j = new Tuple<int, int, int>(i, rand.Next(15), rand.Next(1,15));
                output[i] = j;
            }

            return output;
        }
    }
}
