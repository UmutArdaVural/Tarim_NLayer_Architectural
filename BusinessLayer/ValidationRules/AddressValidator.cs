using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Adress>
    {
        public AddressValidator() 
        {
            RuleFor(x=>x.Description2).NotEmpty();
            RuleFor(x => x.Description1).NotEmpty();
            RuleFor(x => x.Description3).NotEmpty();
            RuleFor(x => x.Description4).NotEmpty();
            RuleFor(x => x.Mapinfo).NotEmpty();

        }
    }
}
