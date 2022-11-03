using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class PortfolioValidation : AbstractValidator<Portfolio>
    {
        public PortfolioValidation()
        {
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Image alani bos birakilamaz");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title alani bos birakilamaz")
                .MaximumLength(25).WithMessage("Title en fazla 25 karakter olabilir");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description alani bos birakilamaz")
                .MaximumLength(50).WithMessage("Description en fazla 50 karakter olabilir.");
        }
    }
}
