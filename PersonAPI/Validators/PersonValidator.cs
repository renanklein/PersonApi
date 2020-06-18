using FluentValidation;
using PersonAPI.Models.Request;
using PersonAPI.Validators.Common;

namespace PersonAPI.Validators
{
    public class PersonValidator : AbstractValidator<PersonRequest>
    {
        public PersonValidator()
        {
            this.RuleFor(person => person.Name).NotEmpty().MaximumLength(300);
            this.RuleFor(person => person.Age).NotEmpty();
            this.RuleFor(person => person.Address).SetValidator(new AddressValidator());
            this.RuleFor(person => person.Document).SetValidator(new DocumentValidator());
        }
    }
}
