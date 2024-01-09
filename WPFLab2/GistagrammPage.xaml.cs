using System.Windows;
using BusinessLog;
using Ninject;
using ScottPlot;
namespace WPFLab2
{
    public partial class GistagrammPage : Window
    {
        public GistagrammPage(Logic logic)
        {
            DataContext = logic;
            InitializeComponent();
            
        }
    }
}