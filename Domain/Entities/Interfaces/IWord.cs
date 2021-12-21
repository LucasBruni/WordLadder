using System.Linq;

namespace Domain.Entities.Interfaces
{
    /// <summary>
    /// Word class.
    /// </summary>
    public interface IWord
    {
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
