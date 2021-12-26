using Core;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Word Ladder Service.
    /// </summary>
    public class WordLadderService : IWordLadderService
    {
        /// <inheritdoc/>
        public IEnumerable<WordModel> FindWordLadder(WordModel firstWord, WordModel targetWord, IEnumerable<WordModel> availableWords)
        {
            var finalResult = new List<WordModel>() { firstWord };
            var allPossibleWordMatches = new List<List<WordModel>>() { finalResult };

            do
            {
                finalResult = this.GetNextGroupOfPossibleMatches(targetWord, availableWords, ref allPossibleWordMatches).ToList();
            }
            while (finalResult.Count() == 0 && allPossibleWordMatches.Count() != 0);

            return finalResult;
        }

        /// <inheritdoc/>
        public bool Validate(WordModel firstWord, WordModel targetWord, IEnumerable<WordModel> availableWords)
        {
            var isValid = false;

            var message = new StringBuilder();

            if (firstWord.IsValid == false || firstWord.Length <= 1)
            {
                message.AppendLine("Error: The first word is invalid. Word can only contain letters and need to have at least 2 letters.");
            }

            if (targetWord.IsValid == false || targetWord.Length <= 1)
            {
                message.AppendLine("Error: The target word is invalid.  Word can only contain letters and need to have at least 2 letters.");
            }

            if (firstWord.Value.Equals(targetWord.Value))
            {
                message.AppendLine("Error: The words need to be differents.");
            }

            if (firstWord.Length != targetWord.Length)
            {
                message.AppendLine("Error: The words need to have the same lenght.");
            }

            if (availableWords.IsInList(firstWord) == false)
            {
                message.AppendLine("Error: The first word isn't in the list of available words.");
            }

            if (availableWords.IsInList(targetWord) == false)
            {
                message.AppendLine("Error: The target word isn't in the list of available words.");
            }

            if (message.Length > 0)
            {
                Console.WriteLine(message.ToString());
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Get Next Group Of Possible Matches.
        /// </summary>
        /// <param name="targetWord">Target Word.</param>
        /// <param name="availableWords">Available Words.</param>
        /// <param name="currentPossibleWordMatches">Current Possible Word Matches.</param>
        /// <returns>Next Group of Possible Matches.</returns>
        private IEnumerable<WordModel> GetNextGroupOfPossibleMatches(WordModel targetWord, IEnumerable<WordModel> availableWords, ref List<List<WordModel>> currentPossibleWordMatches)
        {
            var finalResult = new List<WordModel>();

            var newPossibleMatches = new List<List<WordModel>>();
            var isFinished = false;

            try
            {
                Parallel.ForEach(currentPossibleWordMatches, (matchList, state) =>
                {
                    var alikeList = availableWords.Where(x => x.IsLike(matchList.Last()) && !matchList.Any(y => y.Equals(x)));

                    if (alikeList.Any(x => x.Equals(targetWord)))
                    {
                        matchList.Add(targetWord);
                        finalResult = matchList;
                        isFinished = true;
                        state.Break();
                    }

                    if (!isFinished)
                    {
                        foreach (var word in alikeList)
                        {
                            var newMatch = matchList.ToList();
                            newMatch.Add(word);
                            newPossibleMatches.Add(newMatch);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro finding Group of Possible Matches. Error Message: {ex.Message} Inner Message: {ex.InnerException}");
            }

            currentPossibleWordMatches = newPossibleMatches;

            return finalResult;
        }
    }
}
