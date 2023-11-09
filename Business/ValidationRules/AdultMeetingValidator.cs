using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AdultMeetingValidator : AbstractValidator<AdultMeeting>
    {
        public AdultMeetingValidator()
        {
            RuleFor(c => c.UpdateKilo).NotEmpty().WithMessage("Kilo  boş geçilemez.");
            RuleFor(c => c.WaistSize).NotEmpty().WithMessage("Bel Ölçüsü boş geçilemez.");
            RuleFor(c => c.HipSize).NotEmpty().WithMessage("Bel Ölçüsü boş geçilemez.");
            RuleFor(c => c.HaunchSize).NotEmpty().WithMessage("Bel Ölçüsü boş geçilemez.");
            RuleFor(c => c.ArmSize).NotEmpty().WithMessage("Bel Ölçüsü boş geçilemez.");
            RuleFor(c => c.UpdateKilo).Must(BeValidDecimal).WithMessage("Lütfen geçerli bir ondalık sayı girin.");
        }

        private bool BeValidDecimal(decimal value)
        {
            // İstediğiniz özel kontrolü burada gerçekleştirin
            // Örneğin: return value.ToString("N2").Length <= 10;

            return true; // Örnek bir kontrol, her zaman geçerli
        }
    }
}
