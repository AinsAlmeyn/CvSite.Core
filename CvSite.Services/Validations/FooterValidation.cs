using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class FooterValidation : AbstractValidator<Footer>
    {
        public FooterValidation()
        {
            RuleFor(x => x.Instagram)
                .NotEmpty().WithMessage("Instagram alani bos birakilamaz");

            RuleFor( x=> x.Linkedin)
                .NotEmpty().WithMessage("Linkedin alani bos birakilamaz");
        }
    }
}
