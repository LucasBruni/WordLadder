using Core;
using FluentValidation;
using Services.Exceptions;
using Services.Models;
using System.Collections.Generic;

namespace Services.Validators
{
    /// <summary>
    /// Word Model Validator Class.
    /// </summary>
    public class WordLadderValidator : WordModelValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordLadderValidator"/> class.
        /// </summary>
        public WordLadderValidator(WordModel targetWord, IEnumerable<WordModel> availableWords)
            : base()
        {
            this.RuleFor(w => w)
                .Must(w => !w.Equals(targetWord))
                .OnAnyFailure(f => throw new SameWordsException());

            this.RuleFor(w => w)
                .Must(w => w.Length.Equals(targetWord.Length))
                .OnAnyFailure(f => throw new DifferentWordLengthException());

            this.RuleFor(w => w)
                .Must(w => availableWords.IsInList(w))
                .OnAnyFailure(f => throw new WordNotAvailableInListException(f.Value));

            this.RuleFor(w => w)
                .Must(w => availableWords.IsInList(targetWord))
                .OnAnyFailure(f => throw new WordNotAvailableInListException(targetWord.Value));
        }
    }
}
