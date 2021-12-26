using FluentValidation;
using Services.Exceptions;
using Services.Models;

namespace Services.Validators
{
    /// <summary>
    /// Word Model Validator Class.
    /// </summary>
    public class WordModelValidator : AbstractValidator<WordModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordModelValidator"/> class.
        /// </summary>
        public WordModelValidator()
        {
            this.RuleFor(w => w.Value).NotEmpty();

            this.RuleFor(w => w.Length).GreaterThanOrEqualTo(2)
                .OnAnyFailure(f => throw new InvalidWordValueException());

            this.RuleFor(w => w.IsValid).Must(isValid => isValid == true)
                .OnAnyFailure(f => throw new InvalidWordValueException());
        }
    }
}
