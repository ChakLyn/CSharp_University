//-----------------------------------------------------------------------
// <copyright file="IContainer.cs" company="My Company">
//     Some info
// </copyright>
//-----------------------------------------------------------------------

namespace Lab_1_931
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface is created for giving behavior
    /// of the container for classes how implements
    /// this interface
    /// </summary>
    /// <typeparam name="TValue">New some type of the parameter
    /// takes from class which implements this interface</typeparam>
    public interface IContainer<TValue>
    {
        /// <summary>
        /// Gets a value of object's count
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Indexer method which give the opportunity to access
        /// the object in container with index.
        /// </summary>
        /// <param name="index">Integer type of index</param>
        /// <returns>TValue type with </returns>
        TValue this[int index] { get; set; }

        /// <summary>
        /// This method adds new humans' object in HumanContainer
        /// </summary>
        /// <param name="newElement">Human mas type of the hum</param>
        void Add(params TValue[] newElement);

        /// <summary>
        /// This method will delete object from container
        /// </summary>
        /// <param name="elementToDel">Type of parameter is taken from container generic type
        /// of container which implements this interface</param>
        void Delete(params TValue[] elementToDel);
    }
}
