using System;

namespace Services.Exceptions
{
    /// <summary>
    /// Same Words Exception Class.
    /// </summary>
    public class SameWordsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SameWordsException"/> class.
        /// </summary>
        public SameWordsException()
            : base(string.Format("Error: The words need to be differents."))
        {
        }
    }
}
