using FluentValidation;
using PersonAPI.Models.Request;

namespace PersonAPI.Validators.Common
{
    public class AddressValidator : AbstractValidator<AddressRequest>
    {
        public AddressValidator()
        {
            this.RuleFor(addr => addr.Number).NotEmpty();
            this.RuleFor(addr => addr.Street).NotEmpty();
            this.RuleFor(addr => addr.Neighborhood).NotEmpty();
            this.RuleFor(addr => addr.State).NotEmpty();
            this.RuleFor(addr => addr.ZipCode).NotEmpty();
        }
    }
}
