//-----------------------------------------------------------------------
// <copyright file="IFileContainer.cs" company="My Company">
//     Some info
// </copyright>
//-----------------------------------------------------------------------

namespace Lab_1_931
{
    using System;

    /// <summary>
    /// This interface extends IContainer interface 
    /// </summary>
    /// <typeparam name="TValue">New some type of the parameter
    /// takes from class which implements this interface</typeparam>
    public interface IFileContainer<TValue> : IContainer<TValue>
    {
        /// <summary>
        /// Gets a value indicating whether saved state
        /// </summary>
        bool IsDataSaved { get; }

        /// <summary>
        /// This method saves current object in file with name
        /// which is contained in string parameter
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        void Save(string fileName);

        /// <summary>
        /// Load list of human into container from .xml file
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        void Load(string fileName);
    }
}
