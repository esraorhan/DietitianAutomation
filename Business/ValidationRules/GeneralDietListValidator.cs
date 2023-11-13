using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class GeneralDietListValidator : AbstractValidator<GeneralDietList>
    {
        public GeneralDietListValidator()
        {
            RuleFor(c => c.DietName).NotEmpty().WithMessage("Diyet başlığı  boş geçilemez.");
            RuleFor(c => c.TotalCalories).NotEmpty().WithMessage("Tahmini kalori  boş geçilemez.");
        }
    }
}
