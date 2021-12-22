using Services.Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    /// <summary>
    /// Word Ladder Service Interface.
    /// </summary>
    public interface IWordLadderService
    {
        /// <summary>
        /// Find Word Ladder.
        /// </summary>
        /// <param name="firstWord">First Word.</param>
        /// <param name="targetWord">Target Word.</param>
        /// <param name="availableWords">Available Words.</param>
        /// <returns>Word Ladder Result.</returns>
        public IEnumerable<WordModel> FindWordLadder(WordModel firstWord, WordModel targetWord, IEnumerable<WordModel> availableWords);
    }
}
