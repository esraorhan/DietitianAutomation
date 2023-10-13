using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class FoodValidator : AbstractValidator<Food>
    {
        public FoodValidator()
        {
            RuleFor(c => c.FoodName).NotEmpty().WithMessage("Besin adı boş geçilemez.");
            RuleFor(c => c.CategoryID).NotEmpty().WithMessage("Kategorisini Seçiniz.");
            RuleFor(c => c.Amount).NotEmpty().WithMessage("Miktarını yazınız.");
            RuleFor(c => c.UnitOfMeasure).NotEmpty().WithMessage("Ölçü Birimini seçiniz.");
            RuleFor(c => c.Carbohydrate).NotEmpty().WithMessage("Karbonhidrat değerini giriniz.");
               
            
            RuleFor(c => c.Protein).NotEmpty().WithMessage("Protein değerini giriniz.");
            RuleFor(c => c.Calorie).NotEmpty().WithMessage("Kalori değerini giriniz.");
            RuleFor(c => c.Oil).NotEmpty().WithMessage("Yağ değerini giriniz.");
        }
    }
}
