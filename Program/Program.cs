using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Program
{

    public class Program
    {
        // for sequence storage 
        String seq = "";
        public void roundRobin(String[] process, int[] arrival,
                                        int[] burst, int[] priority, int quantum)
        {
            seq = "";
            // result of average times 
            int res = 0;
            int resc = 0;
            int rest = 0;

            int length = priority.Length;

            // copy the burst array and arrival array 
            // for not effecting the actual array 
            int[] res_burst = new int[burst.Length];
            int[] res_arrival = new int[arrival.Length];
            int[] res_priority = new int[priority.Length];
            // List that will determine queue order based on priority values
            int[] priorityOrder = new int[priority.Length];
            // Comparison list to help make priorityOrder
            int[] priorityComp = new int[priority.Length];


            for (int i = 0; i < res_burst.Length; i++)
            {
                res_burst[i] = burst[i];
                res_arrival[i] = arrival[i];
                res_priority[i] = priority[i];
                priorityOrder[i] = priority[i];
                priorityComp[i] = priority[i];
            }

            // Priority-based order
            Array.Sort(priorityOrder);
            Array.Reverse(priorityOrder);
            for (int i = 0; i < process.Length; i++)
            {
                for(int j = 0; j < process.Length; j++)
                {
                    if (priorityOrder[i] == priorityComp[j])
                    {
                        priorityOrder[i] = j;
                        // *Assuming we dont accept negative priority values
                        // Makes sure the value isnt checked again
                        priorityComp[j] = -1;
                        break;
                    }
                }
            }


            // critical time of system 
            int t = 0;

            // for store the waiting time 
            int[] w = new int[process.Length];

            // for store the Completion time 
            int[] comp = new int[process.Length];

            // for store the TurnAround time 
            int[] tat = new int[process.Length];

            // Variable to help monitor scheduling progress
            int completionCounter = 0;
            Boolean leave = false;
            int index = 0;
            int idleCheck = 0;
            Boolean idlePermit = false;

            while (!leave)
            {
                // Keeps "pIdle" from repeating
                idleCheck = 0;
                idlePermit = true;
                for (int i = 0; i < priority.Length; i++)
                {
                    // Cycles through list in priority-based order
                    index = priorityOrder[i];
                    // Check if process has arrived
                    if (res_arrival[index] <= t)
                    {
                        // Check if process has been completed
                        if (res_burst[index] > 0)
                        {
                            // A process is ready
                            if (res_burst[index] > quantum)
                            {
                                // decrease the burst time 
                                t = t + quantum;
                                res_burst[index] = res_burst[index] - quantum;
                                seq += "->" + process[index] + " ";
                                idlePermit = false;
                                idleCheck = 0;
                            }
                            else
                            {
                                // Process is completing
                                t = t + res_burst[index];

                                // Store completion time 
                                comp[index] = t;

                                // Turn around time
                                tat[index] = t - arrival[index];

                                // Wait time 
                                w[index] = tat[index] - burst[index];
                                res_burst[index] = 0;

                                // Update sequence
                                seq += "->" + process[index] + " ";
                                idlePermit = false;

                                // Update number of completed processes
                                completionCounter++;
                                idleCheck = 0;
                            }
                        }
                        // Increase becuase no process was found
                        else
                        {
                            idleCheck++;
                        }
                    }
                    // Increase becuase no process was found
                    else
                    {
                        idleCheck++;
                    }

                    // pIdle control
                    if (idleCheck == priority.Length && idlePermit)        // Then there are no processes in the ready queue
                    {
                        // Increment time
                        t = t + quantum;
                        // Check if "pIdle" was the last sequence string update
                        if (idlePermit)
                        {
                            seq += "->pIdle ";
                        }
                        idlePermit = false;
                        idleCheck = 0;
                    }

                    // Check if all processes are complete
                    if (completionCounter == priority.Length)
                    {
                        leave = true;
                    }
                }

                
                // for exiting the while loop 
                if (leave)
                {
                    break;
                }
                
            }

            Console.WriteLine("Process\tBurst\tPriority  Arrival   Finish   Turnaround   Waiting Time");
            for (int i = 0; i < process.Length; i++)
            {
                Console.WriteLine(" " + process[i] + "\t\t" + burst[i] + "\t\t" + priority[i] + "\t\t  " + arrival[i] + "\t\t\t" +
                                    comp[i] + "\t\t\t" + tat[i] + "\t\t\t" + w[i]);

                res = res + w[i];
                resc = resc + comp[i];
                rest = rest + tat[i];
            }

            //set Gannt, TaT, wait
            Gannt = seq;
            TaT = (float)rest / process.Length;
            WaitT = (float)res / process.Length;

            Console.WriteLine("Average waiting time is " +
                                WaitT);
            Console.WriteLine("Average turnaround time is " +
                                    TaT);
            Console.WriteLine("Gannt chart is like: " + Gannt);
        }

        //getters and setters for gannt, tat, wait
        public string Gannt { get; set; }
        public float TaT { get; set; }
        public float WaitT { get; set; }

        // Driver Code 
        public static void Main(String[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // name of the process 
            String[] name = { "p1", "p2", "p3", "p4", "p5", "p6" };

            // arrival for every process 
            int[] arrivaltime = { 0, 25, 30, 50, 100, 105 };

            // burst time for every process 
            int[] bursttime = { 15, 25, 20, 15, 15, 10 };

            //priority for each process
            int[] priority = { 40, 30, 30, 35, 5, 10 };


            // quantum time of each process 
            //int q = 10;

            // Create a Button object  
            Button calcButton = new Button();

            // cal the function for output 
            //roundRobin(name, arrivaltime, bursttime, priority, q);
        }
    }
}
