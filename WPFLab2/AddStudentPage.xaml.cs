using System.Windows;
using BusinessLog;
using Ninject;

namespace WPFLab2
{
    public partial class AddStudentPage : Window
    {
        // public Logic logic;

        public AddStudentPage(Logic logic)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            // this.logic = ninjectKernel.Get<Logic>();
            InitializeComponent();
            DataContext = logic;
        }
    }
}