// This file has been created for creating IContainer interface

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1_931
{
    /// <summary>
    /// Interface is created for giving behavior
    /// of the container for classes how implements
    /// this interface
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Indexer method which give the opportunity to access
        /// the object in container with index.
        /// </summary>
        /// <param name="index">Integer type of index</param>
        /// <returns>object type with </returns>
        object this[int index] { get; set; }
    }
}
