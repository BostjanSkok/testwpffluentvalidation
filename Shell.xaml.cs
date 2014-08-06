using System.Windows;
using Microsoft.Practices.Unity;
using TestWpfFluentValidation.Validators;

namespace TestWpfFluentValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private readonly IUnityContainer _container;
            
        public Shell(IUnityContainer container)
        {
            _container = container;
            InitializeComponent();
            this.DataContext = container.Resolve<Person>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = this.DataContext as Person;
            var b =  a.IsValid;
        }
    }
}
