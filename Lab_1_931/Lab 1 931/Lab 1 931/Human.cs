// This file has been created for creating Human class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1_931
{
    /// <summary>
    /// Class Human represents human's essence
    /// </summary>
    public class Human
    {
        /// <summary>
        /// This field contain human's name
        /// </summary>
        private string name;

        /// <summary>
        /// This field contain human's age
        /// </summary>
        private int age;

        /// <summary>
        /// This field contain human's weight
        /// </summary>
        private float weight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class.
        /// </summary>
        /// <param name="newName">string type for initializing name's field</param>
        /// <param name="newAge">integer type for initializing age's field</param>
        /// <param name="newWeigth">float type for initializing weight's field</param>
        public Human(string newName = "Ben", int newAge = 20, float newWeigth = 50f)
        {
            name = newName;
            age = newAge;
            weight = newWeigth;
        }

        /// <summary>
        /// Gets or sets values of the name's field 
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                try
                {
                    name = value;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Inccorect argument of name, please try again!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Gets or sets age's field
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                try
                {
                    age = value;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Inccorect argument of age, please try again!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Gets or sets weight's field
        /// </summary>
        public float Weight
        {
            get
            {
                return weight;
            }

            set
            {
                try
                {
                    weight = value;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Inccorect argument of weight, please try again!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// This method overloads ToString method 
        /// and returns information about human's name, age and weight
        /// </summary>
        /// <returns>string type returning</returns>
        public override string ToString()
        {
            return string.Format("***\nMy name is {0}.\nI am {1} years old.\nI am {2} kg of weight!\n***\n", name, age, weight);
        }
    }
}
