using System;
using System.ComponentModel;
using System.Linq;
using FluentValidation.Results;

namespace TestWpfFluentValidation.Validators
{
    [Serializable]
    public abstract class BaseEntity : INotifyPropertyChanged, IDataErrorInfo
    {

        public Guid CreatedBy { get; set; }
        public Guid ChangedBy { get; set; }
        public DateTime CreatedDtTm { get; set; }
        public DateTime ChangedDtTm { get; set; }
        public Byte[] Version { get; set; }

      


        public void RaisePropertyChanged(params string[] propertyName)
        {
            propertyName.ToList().ForEach(x =>
                                              {
                                                  if (PropertyChanged != null)
                                                      PropertyChanged(this, new PropertyChangedEventArgs(x));
                                              });
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract ValidationResult SelfValidate();
        public abstract ValidationResult SelfValidateProperty(string propertyName);


        public bool IsValid
        {
            get
            {
                OnPropertyChanged(String.Empty);
                return SelfValidate().IsValid;
             
            }
        }

        public string Error
        {
            get { return null; } //return ValidationHelper.GetError(SelfValidate()); }
        }

        public string this[string columnName]
        {
            get
            {
                var __ValidationResults = SelfValidateProperty(columnName);
                if (__ValidationResults == null) return string.Empty;
                var __ColumnResults =
                    __ValidationResults.Errors.FirstOrDefault<ValidationFailure>(
                        x => string.Compare(x.PropertyName, columnName, true) == 0);
                return __ColumnResults != null ? __ColumnResults.ErrorMessage : string.Empty;
            }
        }

      

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}