using System;

namespace Services.Exceptions
{
    /// <summary>
    /// Invalid Word Value Exception.
    /// </summary>
    public class InvalidWordValueException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWordValueException"/> class.
        /// </summary>
        public InvalidWordValueException()
            : base(string.Format("Error: The first word is invalid. Word can only contain letters and need to have at least 2 letters."))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWordValueException"/> class.
        /// </summary>
        /// <param name="name">The Name.</param>
        public InvalidWordValueException(string name)
            : base(string.Format("Error: The first word is invalid. Word can only contain letters and need to have at least 2 letters: {0}", name))
        {
        }
    }
}
