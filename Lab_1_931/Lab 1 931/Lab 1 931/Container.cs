// This file has been created for creating HumanContainer class

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1_931
{
    /// <summary>
    ///  Class HumanContainer stocks inside him humans' objects
    /// </summary>
    public class HumanContainer : IEnumerable, IContainer
    {
        /// <summary>
        /// This field appends needed string for 
        /// creating message which contains all information 
        /// about all Humans' objects
        /// </summary>
        private StringBuilder strBuilder;

        /// <summary>
        /// This field stocks in itself Humans' objects
        /// </summary>
        private List<Human> humans;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanContainer"/> class.
        /// There initializes string builder and list of humans.
        /// </summary>
        public HumanContainer()
        {
            strBuilder = new StringBuilder();
            humans = new List<Human>();
        }

        /// <summary>
        /// Indexer method that implements indexer from
        /// IContainer interface which give the opportunity to access
        /// the object in container with index.
        /// </summary>
        /// <param name="index">Integer type of index</param>
        /// <returns>object type with </returns>
        public object this[int index]
        {
            get
            {
                try
                {
                    return (Human)humans[index];
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                try
                {
                    humans[index] = (Human)value;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Argument out of range exeption!");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// This method adds new humans' object in HumanContainer
        /// </summary>
        /// <param name="hum">Human mas type of the hum</param>
        public void AddHuman(params Human[] hum)
        {
            try
            {
                foreach (Human h in hum)
                {
                    humans.Add(h);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range exeption!");
                Console.ReadLine();
            }
        }
        
        /// <summary>
        /// This method overloads ToString method
        /// </summary>
        /// <returns>string type returning</returns>
        public override string ToString()
        {
            try
            {
                foreach (Human h in humans)
                {
                    strBuilder.Append(h);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("There is nothing to show!");
                Console.ReadLine();
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// This method is created for using 
        /// in foreach construction
        /// </summary>
        /// <returns>IEnumerator type</returns>
        public IEnumerator GetEnumerator()
        {
            return humans.GetEnumerator();
        }
    }
}
