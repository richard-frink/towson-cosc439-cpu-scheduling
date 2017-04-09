using System;
using System.Collections.Generic;

namespace CPU_Scheduling
{
    class Scheduler
    {
        private Queue<Tuple<int, int, int>> processes = new Queue<Tuple<int, int, int>>(); // (process number, arrival time, burst time)
        private Queue<Tuple<int, int, int>> readyQueue = new Queue<Tuple<int, int, int>>(); // Items that have arrived and are waiting
        private Tuple<int, int>[] turnaroundTimes; // (arrival time, completion time)
        private Tuple<int, int, int> currentlyRunning; // currently running process
        private int[] waitTimes; // Will increment appropriate values as time progresses (time waiting in ready queue)
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
            // Loops through all processes
            while(processes.Count > 0)
            {
                checkIfArrived(currentTime);
                // Checks if there are any processes in ready queue
                while (readyQueue.Count > 0)
                {
                    currentlyRunning = readyQueue.Dequeue();
                    // If yes, then we proceed to let the process run
                    for(int i = 0; i < currentlyRunning.Item3; i++)
                    {
                        Console.WriteLine(currentTime + ": Process" + currentlyRunning.Item1 + " running with " + (currentlyRunning.Item3 - i) + " seconds left.");
                        currentTime++;
                        turnaroundTimes[currentlyRunning.Item1] = new Tuple<int, int>(currentlyRunning.Item2, currentTime);
                        checkIfArrived(currentTime);
                        updateWaitTimes();
                    }
                }
                // If no waiting processes, runs until processes are moved to readyqueue
                if(readyQueue.Count == 0)
                {
                    currentTime++;
                    checkIfArrived(currentTime);
                }
            }
            printOutput();
        }

        private void checkIfArrived(int time)
        {
            Queue<Tuple<int, int, int>> temp = new Queue<Tuple<int, int, int>>();
            while(processes.Count > 0)
            {
                if(processes.Peek().Item2 == time)
                {
                    readyQueue.Enqueue(processes.Dequeue());
                }
                else
                {
                    temp.Enqueue(processes.Dequeue());
                }
            }
            while (temp.Count > 0)
            {
                processes.Enqueue(temp.Dequeue());
            }
        }

        private void updateWaitTimes()
        {
            Queue<Tuple<int, int, int>> temp = new Queue<Tuple<int, int, int>>();
            while (readyQueue.Count > 0)
            {
                Tuple<int, int, int> t = readyQueue.Dequeue();
                waitTimes[t.Item1] = waitTimes[t.Item1] + 1;
                temp.Enqueue(t);
            }
            while (temp.Count > 0)
            {
                readyQueue.Enqueue(temp.Dequeue());
            }
        }

        private void processInputs(Tuple<int, int, int>[] userProcesses)
        {
            turnaroundTimes = new Tuple<int, int>[userProcesses.Length];
            waitTimes = new int[userProcesses.Length];
            for (int i = 0; i < userProcesses.Length; i++)
            {
                waitTimes[i] = 0;
                processes.Enqueue(userProcesses[i]);
                turnaroundTimes[i] = new Tuple<int, int> (userProcesses[i].Item2, -1); // Will be changed from -1 to actual completion time
            }
        }

        public void printOutput()
        {
            Console.WriteLine("{0,10} {1,10} {2,15}", "Process#", "Waiting", "Turnaround");
            for(int i = 0; i < waitTimes.Length; i++)
            {
                Console.WriteLine("{0,10} {1,10} {2,15}", i, waitTimes[i], turnaroundTimes[i].Item2 - turnaroundTimes[i].Item1);
            }
        }
    }
}
