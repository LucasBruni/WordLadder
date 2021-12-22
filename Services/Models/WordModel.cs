using System.Linq;

namespace Services.Models
{
    /// <summary>
    /// Word Dto Class.
    /// </summary>
    public class WordModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordModel"/> class.
        /// </summary>
        /// <param name="value">The word.</param>
        public WordModel(string value)
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

        /// <summary>
        /// Gets a value indicating whether the words are alike.
        /// </summary>
        /// <param name="word">Word.</param>
        /// <returns>If the words are alike.</returns>
        public bool IsLike(WordModel word)
        {
            int diff = 0;
            for (int i = 0; i < this.Value.Length; i++)
            {
                if (this.Value[i] != word.Value[i])
                {
                    diff++;
                }
            }

            return diff == 1;
        }
    }
}
