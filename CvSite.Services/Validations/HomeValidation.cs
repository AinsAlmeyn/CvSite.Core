using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class HomeValidation : AbstractValidator<Home>
    {
        public HomeValidation()
        {
            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage("Photo alani bos birakilamaz");

            RuleFor(x => x.Jobs)
                .NotEmpty().WithMessage("Jobs alani bos birakilamaz");

            RuleFor(x => x.LinkInstagram)
                .NotEmpty().WithMessage("Link Instagram alani bos birakilamaz");

            RuleFor(x => x.LinkLinkedin)
                .NotEmpty().WithMessage("Link Linkedin alani bos birakilamaz");
        }
    }
}
