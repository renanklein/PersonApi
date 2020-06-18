using FluentValidation;
using PersonAPI.Models.Request;

namespace PersonAPI.Validators.Common
{
    public class DocumentValidator : AbstractValidator<DocumentRequest>
    {
        public DocumentValidator()
        {
            RuleFor(doc => doc.DocumentNumber).NotEmpty();
            RuleFor(doc => doc.DocumentType)
                .IsInEnum()
                .WithMessage("An valid documentType must be informed");
        }
    }
}
