using System;

namespace Services.Exceptions
{
    /// <summary>
    /// Different Word Length Exception Class.
    /// </summary>
    public class DifferentWordLengthException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DifferentWordLengthException"/> class.
        /// </summary>
        public DifferentWordLengthException()
            : base("Error: The words need to have the same lenght.")
        {
        }
    }
}
