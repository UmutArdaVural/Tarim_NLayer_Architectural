using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Olamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Boş Olamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Boş Olamaz");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Facebook Adresi Boş Olamaz");
            RuleFor(x => x.XUrl).NotEmpty().WithMessage("X Adresi Boş Olamaz");
            RuleFor(x => x.WebSiteUrl).NotEmpty().WithMessage("WEB SİTESİ  Adresi Boş Olamaz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim Karakter sayisi 50 karakteri geçemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("5 KARAKTERDEN FAZLA GİRİNİZ");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("3 KARAKTERDEN FAZLA GİRİNİZ");



        }
    }
}
