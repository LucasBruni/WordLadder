using System.Linq;
using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    /// <summary>
    /// Word class.
    /// </summary>
    public class Word : IWord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// </summary>
        /// <param name="value">The word.</param>
        public Word(string value)
        {
            this.Value = value;
        }

        /// <inheritdoc/>
        public string Value { get; }

        /// <inheritdoc/>
        public int Length => this.Value.Length;

        /// <inheritdoc/>
        public bool IsValid => this.Value.All(char.IsLetter);
    }
}
