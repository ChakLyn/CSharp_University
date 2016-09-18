//-----------------------------------------------------------------------
// <copyright file="Container.cs" company="My Company">
//     Some info
// </copyright>
//-----------------------------------------------------------------------

namespace Lab_1_931
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Class which contains humans
    /// </summary>
    /// <typeparam name="TValue">Which humans will be added</typeparam>
    public class HumanContainer<TValue> : IEnumerable, IFileContainer<TValue> where TValue : Human
    {
        /// <summary>
        /// This field stocks in itself Humans' objects
        /// </summary>
        private List<TValue> humans;

        /// <summary>
        /// True if data is saved
        /// False in opposite way
        /// </summary>
        private bool dataSaved;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanContainer{TValue}"/> class.
        /// </summary>
        public HumanContainer()
        {
            this.humans = new List<TValue>();
        }

        /// <summary>
        /// Gets a value indicating whether saved state
        /// </summary>
        public bool IsDataSaved
        {
            get
            {
                return this.dataSaved == true;
            }
        }

        /// <summary>
        /// Gets a value of object's count
        /// </summary>
        public int Count
        {
            get
            {
                return this.humans.Count;
            }
        }

        /// <summary>
        /// Indexer method that implements indexer from
        /// IContainer interface which give the opportunity to access
        /// the object in container with index.
        /// </summary>
        /// <param name="index">Integer type of index</param>
        /// <returns>object type with </returns>
        public TValue this[int index]
        {
            get
            {
                try
                {
                    return this.humans[index];
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException("Wrong index! The sender is {0}", e);
                }
            }

            set
            {
                try
                {
                    this.humans[index] = value;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Argument out of range exeption! The sender is {0}\n", e);
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// This method adds new humans' object in HumanContainer
        /// </summary>
        /// <param name="hum">Human mas type of the hum</param>
        public void Add(params TValue[] hum)
        {
            try
            {
                foreach (TValue h in hum)
                {
                    this.humans.Add(h);
                    h.StateChanged += this.SomeNews;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Argument out of range exeption! THe sender is {0}", e);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Travel in the future increasing the age of humans
        /// </summary>
        /// <param name="detlaYears">How much years to go</param>
        public void Future(int detlaYears)
        {
            if (detlaYears > 0)
            {
                foreach (TValue h in this.humans)
                {
                    h.Grow(detlaYears);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can't grow back!");
            }
        }

        /// <summary>
        /// Delete humans from container
        /// </summary>
        /// <param name="hum">List of humans to delete</param>
        public void Delete(params TValue[] hum)
        {
            foreach (TValue h in hum)
            {
                h.StateChanged -= this.SomeNews;
                this.humans.Remove(h);
            }
        }

        /// <summary>
        /// This method overloads ToString method
        /// </summary>
        /// <returns>string type returning</returns>
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                foreach (TValue h in this.humans)
                {
                    strBuilder.Append(h);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("There is nothing to show! The sender is {0}", e);
                Console.ReadLine();
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Save list of humans in .xml file
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public void Save(string fileName)
        {
            this.dataSaved = true;
            try
            {
                using (Stream fileStream = new FileStream(
                    fileName + ".xml",
                   FileMode.Create,
                   FileAccess.Write,
                   FileShare.None))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<TValue>));
                    xmlFormat.Serialize(fileStream, this.humans);
                    fileStream.Close();
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Something wrong with file! Try again\n{0}", e);
            }
        }

        /// <summary>
        /// Load list of human into container from .xml file
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public void Load(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TValue>));
            try
            {
                using (FileStream fs = new FileStream(fileName + ".xml", FileMode.Open))
                {
                    XmlReader reader = XmlReader.Create(fs);
                    this.humans = (List<TValue>)serializer.Deserialize(reader);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Something wrong with deserializisation {0}", e);
            }
        }

        /// <summary>
        /// This method is created for using 
        /// in foreach construction
        /// </summary>
        /// <returns>IEnumerator type</returns>
        public IEnumerator GetEnumerator()
        {
            return this.humans.GetEnumerator();
        }

        /// <summary>
        /// Inform about new of the state
        /// </summary>
        /// <param name="sender">which object send a message</param>
        /// <param name="e">arguments of sent information</param>
        private void SomeNews(object sender, HumanEventArgs e)
        {
            if (sender is TValue)
            {
                TValue t = (TValue)sender;
                Console.WriteLine("{0} => says: {1}\n", t.Name, e.Msg);
                this.dataSaved = false;
            }
        }
    }
}
