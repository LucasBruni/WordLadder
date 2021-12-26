using System.Linq;

namespace Domain.Entities
{
    /// <summary>
    /// Word class.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// </summary>
        /// <param name="value">The word.</param>
        public Word(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the Length of the word.
        /// </summary>
        public int Length => this.Value.Length;

        /// <summary>
        /// Gets a value indicating whether is Valid.
        /// </summary>
        public bool IsValid => this.Value.All(char.IsLetter);
    }
}
