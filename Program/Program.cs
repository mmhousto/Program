using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{

    public class Program
    {
        public void roundRobin(String[] p, int[] a,
                                        int[] b, int[] pr, int n)
        {
            // result of average times 
            int res = 0;
            int resc = 0;
            int rest = 0;

            // for sequence storage 
            String seq = "";

            // copy the burst array and arrival array 
            // for not effecting the actual array 
            int[] res_b = new int[b.Length];
            int[] res_a = new int[a.Length];
            int[] res_pr = new int[pr.Length];

            for (int i = 0; i < res_b.Length; i++)
            {
                res_b[i] = b[i];
                res_a[i] = a[i];
                res_pr[i] = pr[i];
            }

            // critical time of system 
            int t = 0;

            // for store the waiting time 
            int[] w = new int[p.Length];

            // for store the Completion time 
            int[] comp = new int[p.Length];

            // for store the TurnAround time 
            int[] tat = new int[p.Length];

            while (true)
            {
                Boolean flag = true;
                for (int i = 0; i < p.Length; i++)
                {

                    // these condition for if 
                    // arrival is not on zero 
                    // check that if there come before qtime 
                    if (res_a[i] <= t)
                    {
                        if (res_a[i] <= n)
                        {
                            if (res_b[i] > 0)
                            {
                                flag = false;
                                if (res_b[i] > n)
                                {

                                    // make decrease the b time 
                                    t = t + n;
                                    res_b[i] = res_b[i] - n;
                                    res_a[i] = res_a[i] + n;
                                    seq += "->" + p[i];
                                }
                                else
                                {

                                    // for last time 
                                    t = t + res_b[i];

                                    // store comp time 
                                    comp[i] = t;

                                    //turn around time
                                    tat[i] = t - a[i];

                                    // store wait time 
                                    w[i] = tat[i] - b[i];
                                    res_b[i] = 0;

                                    // add sequence 
                                    seq += "->" + p[i];
                                }
                            }
                        }
                        else if (res_a[i] > n)
                        {

                            // is any have less arrival time 
                            // the coming process then execute them 
                            for (int j = 0; j < p.Length; j++)
                            {

                                // compare 
                                if (res_a[j] < res_a[i])
                                {
                                    if (res_b[j] > 0)
                                    {
                                        flag = false;
                                        if (res_b[j] > n)
                                        {
                                            t = t + n;
                                            res_b[j] = res_b[j] - n;
                                            res_a[j] = res_a[j] + n;
                                            seq += "->" + p[j];
                                        }
                                        else
                                        {
                                            t = t + res_b[j];
                                            comp[j] = t;
                                            tat[j] = t - a[j];
                                            w[j] = tat[j] - b[j];
                                            res_b[j] = 0;
                                            seq += "->" + p[j];
                                        }
                                    }
                                }
                            }

                            // now the previous porcess according to 
                            // ith is process 
                            if (res_b[i] > 0)
                            {
                                flag = false;

                                // Check for greaters 
                                if (res_b[i] > n)
                                {
                                    t = t + n;
                                    res_b[i] = res_b[i] - n;
                                    res_a[i] = res_a[i] + n;
                                    seq += "->" + p[i];
                                }
                                else
                                {
                                    t = t + res_b[i];
                                    comp[i] = t;
                                    tat[i] = t - a[i];
                                    w[i] = tat[i] - b[i];
                                    res_b[i] = 0;
                                    seq += "->" + p[i];
                                }
                            }
                        }
                    }

                    // if no process is come on thse critical 
                    else if (res_a[i] > t)
                    {
                        t += n;
                        i--;
                        seq += "->pIdle";
                    }
                }

                // for exit the while loop 
                if (flag)
                {
                    break;
                }
            }

            Console.WriteLine("Process\tBurst\tPriority  Arrival   Finish   Turnaround   Waiting Time");
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(" " + p[i] + "\t\t" + b[i] + "\t\t" + pr[i] + "\t\t  " + a[i] + "\t\t\t" +
                                    comp[i] + "\t\t\t" + tat[i] + "\t\t\t" + w[i]);

                res = res + w[i];
                resc = resc + comp[i];
                rest = rest + tat[i];
            }

            Console.WriteLine("Average waiting time is " +
                                (float)res / p.Length);
            Console.WriteLine("Average turnaround time is " +
                                    (float)rest / p.Length);
            Console.WriteLine("Gannt chart is like: " + seq);
        }

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
            int q = 10;

            // Create a Button object  
            Button calcButton = new Button();

            // cal the function for output 
            //roundRobin(name, arrivaltime, bursttime, priority, q);
        }
    }
}
