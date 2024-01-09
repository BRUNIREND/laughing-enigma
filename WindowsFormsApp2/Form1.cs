using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLog;
using Mod;
using System.Windows.Forms;
using Ninject;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Add_student_view f2;
        private Gistagramm f3;
        private Form1 f1;
        private Logic logic;
        public Form1()
        {
            InitializeComponent();
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<Logic>();
            // Первичная загрузка данных из таблицы
            foreach (var wr in logic.Read_from_file())
            {
                if (wr != "" && wr != " ") Students1_box.Items.Add(wr);
                //Добавляем данные в таблицу
            }  
            FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }

        
        /// <summary>
        /// Кнопка добавления новго пользователя
        /// </summary>
        private void Add_new_student_Click(object sender, EventArgs e)
        {
            // Создание и открытие новой формы
            f2 = new Add_student_view(logic);
            f2.Show();
            this.Hide();


        }
        /// <summary>
        /// Удаления выбранного пользователя
        /// </summary>
        private void Delete_chose_student_Click(object sender, EventArgs e)
        {
            char[] a = { ' ' };
            
            // Получаем элемент на удаление
            string[] text_person_for_delete = Students1_box.Items[Students1_box.Items.IndexOf(Students1_box.SelectedItem)].ToString().Split(a);
            // Вызываем метод удаления студента
            if (text_person_for_delete.Length == 5)
            {
                logic.DeleteStudent(text_person_for_delete[0] + " " + text_person_for_delete[1] +" "+ text_person_for_delete[2], text_person_for_delete[3], text_person_for_delete[4]);
            }
            else if (text_person_for_delete.Length == 4)
            {
                logic.DeleteStudent(text_person_for_delete[0] + " " + text_person_for_delete[1] , text_person_for_delete[2], text_person_for_delete[3]);
                
            }
            else if (text_person_for_delete.Length == 3)
            {
                logic.DeleteStudent(text_person_for_delete[0], text_person_for_delete[1], text_person_for_delete[2]);
            }

            // Удаляем из формы
            Students1_box.Items.Remove(Students1_box.SelectedItem);
        }

        /// <summary>
        ///  Показ гистограммы
        /// </summary>
        private void View_gistogramm_Click(object sender, EventArgs e)
        {
            // Создаем и выводим форму с гистограммов
            f3 = new Gistagramm(logic);
            f3.Show();
        }

    }
}