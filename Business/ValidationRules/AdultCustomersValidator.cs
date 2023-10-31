using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AdultCustomersValidator : AbstractValidator<AdultCustomer>
    {
        public AdultCustomersValidator()
        {
            RuleFor(c => c.FullName).NotEmpty().WithMessage("Adı ve soyad adı boş geçilemez.");
            RuleFor(c => c.Gender).NotEmpty().WithMessage("Cinsiyet boş geçilemez.");
            RuleFor(c => c.Kilo).NotEmpty().WithMessage("Kilo boş geçilemez.");
            RuleFor(c => c.Size).NotEmpty().WithMessage("Boy boş geçilemez.");
            RuleFor(c => c.Phone).NotEmpty().WithMessage("Boy boş geçilemez.");
            RuleFor(c => c.DateOfBirth).NotEmpty().WithMessage("Boy boş geçilemez.");
        }
    }
}
