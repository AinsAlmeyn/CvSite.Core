using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class NewAboutValidation : AbstractValidator<NewAbout>
    {
        public NewAboutValidation()
        {
            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage("Photo degeri bos gecilemez");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title alani bos gecilemez")
                .MaximumLength(100).WithMessage("Title alani en fazla 100 karkter olabilir");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description alani bos gecilemez")
                .MaximumLength(600).WithMessage("Description alani en fazla 600 karakter olabilir.");
        }
    }
}
