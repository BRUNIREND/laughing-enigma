using System.Windows;
using BusinessLog;
using Ninject;

namespace WPFLab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Logic logic;
        // public Logic logic = new Logic();    
        public MainWindow()
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            this.logic = ninjectKernel.Get<Logic>();
            DataContext = logic;
            

            InitializeComponent();
          
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {
            AddStudentPage addStudentForm = new AddStudentPage(logic);
            
            addStudentForm.Show();
        }

        

        private void Show_Gistagramm(object sender, RoutedEventArgs e)
        {

            var gistagrammForm = new GistagrammPage(logic);
            gistagrammForm.Show();

        }
    }
}