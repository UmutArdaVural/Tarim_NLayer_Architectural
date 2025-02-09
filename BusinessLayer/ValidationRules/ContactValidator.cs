﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public  class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
          RuleFor(x => x.Name).NotEmpty();
          RuleFor(x => x.Message).NotEmpty();
          RuleFor(x => x.Mail).NotEmpty();
          

        }
    }
}
