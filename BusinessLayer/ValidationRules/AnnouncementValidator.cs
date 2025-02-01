using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public  class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İçerik Boş Olamaz");
            




        }
    }
}
