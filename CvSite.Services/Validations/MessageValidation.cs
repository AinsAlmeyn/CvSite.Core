using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class MessageValidation : AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name alani bos birakilamaz")
                .MaximumLength(30).WithMessage("Name alani en fazla 30 karakter olabilir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Email alani bos birakilamaz")
                .EmailAddress().WithMessage("Gecerli bir email adresi giriniz");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject alani bos birakilamaz")
                .MaximumLength(600).WithMessage("En fazla 600 karakter olabilir");

            RuleFor(x => x.FormMessage)
                .NotEmpty().WithMessage("Message alani bos birakilamaz")
                .MaximumLength(1000).WithMessage("Message alani en fazla 1000 karakter olabilir");
        }
    }
}
