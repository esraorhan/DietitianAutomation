using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c=>c.FullName).NotEmpty().WithMessage("Ad soyad boş geçilemez.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(c => c.Phone).NotEmpty().WithMessage("Telefon Numası boş geçilemez.");
        }
    }
}
