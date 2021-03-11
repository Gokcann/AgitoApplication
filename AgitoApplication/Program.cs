using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgitoApplication
{
    class Program
    {
        string post;
        Dictionary<string, int> output = new Dictionary<string, int>();
        Random rnd = new Random();
        static void Main(string[] args)
        {
            /*
             * * * * please uncomment the dataset you want to use for Question2 * * * *
             */

            Program p = new Program();
            List<string> input = new List<string>();
            //dataset for question2
            string[] exampleinput = { "a", "b", "c", "c", "b", "d", "e", "e", "d", "a" };
            //string[] exampleinput = { "a", "b", "c", "c", "d", "d", "b", "e", "e", "a" };

            foreach (string s in exampleinput)
            {
                input.Add(s);
            }
            p.Question1();
            p.Question2(input);

            Console.ReadLine();

        }

        private void Question1()
        {
            List<int> output = new List<int>();
            int min = 1;
            int max = 9;
            int counter = 0;
            int temp;
            bool control = true;
            //to add the first number
            output.Add(RandomFunc(min, max));
            //then automatically checks and adds in do-while blocks
            do
            {
                //the following two if decision is narrow the range of RandomFunc
                if (output.Min() == min)
                {
                    min++;
                }
                if (output.Max() == max)
                {
                    max--;
                }
                temp = RandomFunc(min, max);
                counter++;
                foreach (int i in output.ToList())
                {

                    if (i == temp)
                    {
                        control = false;
                        break;
                    }
                    else
                    {
                        control = true;
                    }
                }
                if (control)
                {
                    output.Add(temp);
                }

            } while (output.Count < 9);

            Console.WriteLine("******Question 1 Solution*****");
            foreach (int j in output)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("\n");
            Console.WriteLine("RandomFunc method call counter: " + counter + "\n");
            Console.WriteLine("******Question 1 Solution*****\n\n\n\n");

        }

        public int RandomFunc(int min, int max)
        {
            int post_random = rnd.Next(min, max + 1);
            return post_random;
        }


        public void Question2(List<string> foo)
        {

            string[] cell = new string[2];
            bool control;
            string temp = "";
            int level = 0;
            int loc = 0;

            foreach (string s in foo)
            {
                if (output.Count != 0)
                {
                    //if the nodes repeats, skip and return to the previous level
                    control = true;
                    foreach (KeyValuePair<string, int> kvp in output.ToList())
                    {
                        if (string.Equals(kvp.Key, s))
                        {
                            control = false;
                            level--;
                            break;
                        }

                    }
                    //if the check(control) is successful, increase the level and continue
                    if (control)
                    {
                        level++;
                        output.Add(s, level);
                    }
                }
                else
                {
                    output.Add(s, level);
                }

            }

            //print result
            Console.WriteLine("******Question 2 Solution*****");
            foreach (KeyValuePair<string, int> kvp in output)
            {
                Console.WriteLine(GetChild(kvp.Value) + " " + kvp.Key);

            }
            Console.WriteLine("******Question 2 Solution*****");
        }

        public string GetChild(int i)
        {
            //create child line method
            post = "";
            for (int j = 0; j < i; j++)
            {
                post = post + "-";
            }
            return post;
        }

    }
} 
