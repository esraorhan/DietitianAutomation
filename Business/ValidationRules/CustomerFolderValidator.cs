using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CustomerFolderValidator : AbstractValidator<CustomerFolder>
    {
        public CustomerFolderValidator()
        {
            RuleFor(c => c.FolderPath).NotEmpty().WithMessage("dosya adı  boş geçilemez.");
            RuleFor(c => c.FolderDescription).NotEmpty().WithMessage("Dosya açıklaması boş geçilemez.");
            RuleFor(c => c.FolderTitle).NotEmpty().WithMessage("Dosya Başlığı boş geçilemez.");
        }
    }
}
