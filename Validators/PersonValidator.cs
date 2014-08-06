using System;
using FluentValidation;

namespace TestWpfFluentValidation.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {



        private Class1 _regI;

        public PersonValidator(Class1 RegI)
        {
            _regI = RegI;

            RuleFor(x => x.FirstName).Length(1, 25).NotEmpty().WithLocalizedMessage(() => ValidationLoc.Empty).Matches(RegI.regEx)
                .WithMessage("FirstName 1 - 25");
            RuleFor(x => x.LastName).Length(1, 25).NotEmpty()
                .WithMessage("LastName" + "1 - 25");
            RuleFor(x => x.Email).EmailAddress().NotEmpty()
                .WithMessage("Email" );
            RuleFor(x => x.Birthday).Must((x, y) => x.Birthday > new DateTime(1900, 1, 1) && x.Birthday < DateTime.Now)
                .WithMessage("Date of birth should be between 01-Jan-1900 and today");

        }
    }
}