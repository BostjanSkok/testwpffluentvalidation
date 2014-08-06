using System;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Practices.Unity;

namespace TestWpfFluentValidation.Validators
{
    public class Person : BaseEntity
    {
        [Dependency]
        public  PersonValidator Validator { get;
            set; }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                     RaisePropertyChanged("FirstName");
                }
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                     RaisePropertyChanged("LastName");
                }
            }
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (value != _birthday)
                {
                    _birthday = value;
                     RaisePropertyChanged("Birthday");
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                     RaisePropertyChanged("Email");
                }
            }
        }


        public override ValidationResult SelfValidate()
        {
           // return ValidationHelper.Validate<PersonValidator, Person>(this); 
          return  Validator.Validate(this);

        }

        public override ValidationResult SelfValidateProperty(string propertyName)
        {
            //return ValidationHelper.Validate<PersonValidator, Person>(this,propertyName); 
             //IValidator<Person> a = 
            return Validator.Validate(this , propertyName);

        }
    }
}
