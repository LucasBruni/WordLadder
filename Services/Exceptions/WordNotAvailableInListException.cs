using System;

namespace Services.Exceptions
{
    /// <summary>
    /// Word Not Available In List Exception.
    /// </summary>
    public class WordNotAvailableInListException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordNotAvailableInListException"/> class.
        /// </summary>
        public WordNotAvailableInListException()
            : base("Error: The word isn't in the list of available words.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordNotAvailableInListException"/> class.
        /// </summary>
        /// <param name="name">The Name.</param>
        public WordNotAvailableInListException(string name)
            : base(string.Format("Error: The word isn't in the list of available words: {0}", name))
        {
        }
    }
}
