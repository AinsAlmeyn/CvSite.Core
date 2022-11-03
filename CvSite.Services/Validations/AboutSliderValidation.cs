using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class AboutSliderValidation : AbstractValidator<AboutSlider>
    {
        public AboutSliderValidation()
        {
            RuleFor(x => x.SliderIcon)
                .NotEmpty().WithMessage("Slider icon bos gecilemez");
            RuleFor(x => x.SliderTitle)
                .MaximumLength(20).WithMessage("Maximum 20 karakter olabilir.")
                .NotEmpty().NotNull().WithMessage("Slider Title bos gecilemez.");
            RuleFor(x => x.SliderShortDescription)
                .NotNull().NotEmpty().WithMessage("Slider Short Description alani bos gecilemez")
                .MaximumLength(120).WithMessage("Slider Short Description alani en fazla 120 karakter olabilir.");
        }
    }
}
