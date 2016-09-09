// This file has been created for creating Programm class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1_931
{
    /// <summary>
    /// Class program is created for testing 
    /// HumanContainer class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method is where program starts
        /// </summary>
        /// <param name="args">Additional arguments</param>
        public static void Main(string[] args)
        {
            HumanContainer humaContainer1 = new HumanContainer();
            HumanContainer humaContainer2 = new HumanContainer(); 
            Console.WriteLine("Creating humans!");

            humaContainer1.AddHuman(new Human("Colin", 14, 34.5f), new Human("Jon", 34, 78f), new Human());
            
            Console.WriteLine("Let's show them!");

            // testing different situations
            Console.WriteLine(humaContainer1);
            try
            {
                Console.WriteLine(humaContainer1[-1]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Wrong index!");
                Console.ReadLine();
            }

            Console.WriteLine(humaContainer2);
        }
    }
}
