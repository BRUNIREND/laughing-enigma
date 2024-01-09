using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BusinessLog;
using Mod;
using Ninject;

namespace WindowsFormsApp2
{
    public partial class Gistagramm : Form
    {
        private Logic logic;
        public Gistagramm(Logic logic)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            this.logic = ninjectKernel.Get<Logic>();
            InitializeComponent();

            // Метод подсчета текущего количества различных специльностей
            logic.Count_specialities();
            
            // Получаем список количества специализаций и сами специализации
            var daysOfWeek = logic.specialities_of_students;
            var numberOfVisitors = logic.count_of_specialities;
            
            // Установим палитру
            chart1.Palette = ChartColorPalette.SeaGreen;
            
            // Заголовок графика
            // Добавляем последовательность
            chart1.Series.Clear();
            for (int i = 0; i < daysOfWeek.Count; i++)
            {
                if (daysOfWeek[i] != "")
                {
                    Series series = chart1.Series.Add(daysOfWeek[i]);
                    series.Points.Add(numberOfVisitors[i]);

                }

                // Добавляем точку
            }
            logic.Clear_specialitties(daysOfWeek, numberOfVisitors);
        }
    }
}