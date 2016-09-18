//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="My Company">
//     Some info
// </copyright>
//-----------------------------------------------------------------------

namespace Lab_1_931
{
    using System;

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
            HumanContainer<Human> humaContainer1 = new HumanContainer<Human>();
            HumanContainer<Human> humaContainer2 = new HumanContainer<Human>();
            Console.WriteLine("Creating humans!");

            humaContainer1.Add(new Human("Colin", 14, 34.5f), new Human("Jon", 34, 78f), new Human());

            Console.WriteLine("Let's show them!");

            Console.WriteLine(humaContainer1);

            humaContainer1[1].Name = "Pedro";

            Console.WriteLine("Let's travel in future!");
            for (int i = 0; i < 6; i++)
            {
                humaContainer1.Future(20);
                Console.WriteLine();
            }

            HumanContainer<Human> humanContainer3 = new HumanContainer<Human>();
            humanContainer3.Add(new Human("Back", 14, 34.5f), new Human("Claw", 34, 78f), new Human());
            Console.WriteLine("Let's travel in time back!");
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    humaContainer1.Future(-10);
                    Console.WriteLine();
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            Console.WriteLine(humanContainer3);
            humanContainer3.Future(10);

            foreach(Human human in humanContainer3)
            {
                Console.WriteLine(human);
            }

            Console.WriteLine("How much people in human container 1? > {0}\n", humaContainer1.Count);

            humaContainer1.Save("New");

            HumanContainer<Human> humanContainer2 = new HumanContainer<Human>();
            humaContainer2.Load("New");

            Console.WriteLine(humaContainer2);

            Console.ReadLine();
        }
    }
}
