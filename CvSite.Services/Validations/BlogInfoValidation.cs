using CvSite.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.Validations
{
    public class BlogInfoValidation : AbstractValidator<BlogInfo>
    {
        public BlogInfoValidation()
        {
            RuleFor(x => x.Image)
                .NotNull().WithMessage("Image alani bos gecilemez");
            RuleFor(x => x.Title)
                .MaximumLength(50).WithMessage("Title alani en fazla 50 karakter olabilir.")
                .NotNull().WithMessage("Title alani bos gecilemez");
            RuleFor(x => x.Description)
                .MaximumLength(100).WithMessage("Description alani en fazla 100 karakter olabilir")
                .NotNull().WithMessage("Description alani bos gecilemez");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author alani bos gecilemez")
                .MaximumLength(30).WithMessage("Author alani en fazla 30 karakter olabilir");
            RuleFor(x => x.CreateDate)
                .NotEmpty().WithMessage("Create Date alani bos gecilemez");
            RuleFor(x => x.MainImage)
                .NotEmpty().WithMessage("Main image alani bos gecilemez.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content alani bos gecilemez")
                .MinimumLength(100).WithMessage("Content alani en az 100 karakter olmalidir.");
        }
    }
}
