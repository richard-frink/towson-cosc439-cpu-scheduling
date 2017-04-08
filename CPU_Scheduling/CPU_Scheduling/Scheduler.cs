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
        public Scheduler(List<Tuple<int, int>> input)
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

        private void processInputs(List<Tuple<int, int>> userProcesses)
        {
            userProcesses.ToArray();
            turnaroundTimes = new Tuple<int, int>[userProcesses.Count];
            waitTimes = new Tuple<int, int>[userProcesses.Count];
            for (int i = 0; i < userProcesses.Count; i++)
            {

            }
        }

        public void printOutput()
        {

        }
    }
}
