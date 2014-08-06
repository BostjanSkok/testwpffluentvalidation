using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using TestWpfFluentValidation.Validators;

namespace TestWpfFluentValidation
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
            //      var a = new Maip.Reports.ObracunReport(1255, new DateTime(2013, 5, 1), new DateTime(2013, 5, 31),null);
            //    a.SaveToDisk(System.IO.Directory.GetCurrentDirectory());
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.RegisterTypeIfMissing(typeof(Person), typeof(Person), true);
            this.RegisterTypeIfMissing(typeof(PersonValidator), typeof(PersonValidator), true);
            this.RegisterTypeIfMissing(typeof(Class1), typeof(Class1), true);




            //  this.Container.RegisterInstance<CallbackLogger>(this.callbackLogger);
        }
    }
}
