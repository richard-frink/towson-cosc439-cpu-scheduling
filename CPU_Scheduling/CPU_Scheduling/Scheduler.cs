using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduling
{
    class Scheduler
    {
        private Tuple<int, int, int>[] processes; // (process number, arrival time, burst time)
        private Tuple<int, int, int>[] readyQueue; // Items that have arrived and are waiting
        private Tuple<int, int>[] turnaroundTimes; // (process number, arrival time, completion time)
        private Tuple<int, int> currentlyRunning; // currently running process
        private Tuple<int, int>[] waitTimes; // Will increment appropriate values as time progresses (process number, time waiting in ready queue)
        private int currentTime;
        
        // Constructor
        public Scheduler(Tuple<int, int, int>[] input)
        {
            processInputs(input);
            currentTime = 0;
        }

        // Once this is started, the scheduler goes through the entire scheduling process
        public void run()
        {
            // Big for loop through the length of the array
            // Per iteration:

                // Inner loop for the burst time

                // Per Iteration:

                // per each second, add to total time clock,
                // subtract time from current process,
                // scan the process queue for any jobs that came in at the given time and put into ready queue.
        }

        private void processInputs(Tuple<int, int, int>[] userProcesses)
        {
            turnaroundTimes = new Tuple<int, int>[userProcesses.Length];
            waitTimes = new Tuple<int, int>[userProcesses.Length];
            for (int i = 0; i < userProcesses.Length; i++)
            {

            }
        }

        public void printOutput()
        {

        }
    }
}
