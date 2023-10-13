using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(c => c.MealName).NotEmpty().WithMessage("Öğün adı boş geçilemez.");
            RuleFor(c => c.MealTime).NotEmpty().WithMessage("Zaman dilimi boş geçilemez.");
          //  RuleFor(c => c.MealTime).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez.");
        }
    }
}
