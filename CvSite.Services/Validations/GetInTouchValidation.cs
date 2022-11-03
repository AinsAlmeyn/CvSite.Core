using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class GetInTouchValidation : AbstractValidator<GetInTouch>
    {
        public GetInTouchValidation()
        {
            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District alani bos birakilamaz");

            RuleFor(x => x.CityCountry)
                .NotEmpty().WithMessage("City/Country alani bos birakilamaz");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber alani bos birakilamaz");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Gecerli bir e mail adresi girin")
                .NotEmpty().WithMessage("Email alani bos birakilamaz");
        }
    }
}
