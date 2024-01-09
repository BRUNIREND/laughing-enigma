using System;
using BusinessLog;
using Mod;
using System.Windows.Forms;
using Ninject;

namespace WindowsFormsApp2
{
    public partial class Add_student_view : Form
    {
        private Logic logic;
        public Add_student_view(Logic logic)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            this.logic = ninjectKernel.Get<Logic>();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        /// <summary>
        ///  Кнопка получения информации о пользователе и добавления в список
        /// </summary>
        private void add_student_Click_1(object sender, EventArgs e)
        {
            
            //Пытаемся получить введеные данные пользователя
            try
            {
                char[] a = { ' ' };
                string speciality = student_speciality.Text;
                string FIO = student_FIO.Text;
                string group = student_group_enter.Text;
                if ((speciality != "" && speciality != " ") && (FIO != "" && FIO != " ") &&
                    (group != "" && group != " ") && (FIO.Split(a).Length >=2))
                {
                    logic.AddStudent(FIO, speciality, group);
                    
                }
                else
                {
                    MessageBox.Show("Please, enter full feeld", "HA HA HA HA HA", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                // Вызываем метод добавления студента

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            this.Close();
            Form1 formm = new Form1();
            formm.Show();
        }

        private void Fio_Click(object sender, EventArgs e)
        {
        }

        private void group_student_Click(object sender, EventArgs e)
        {
        }

        private void student_spicality_Click(object sender, EventArgs e)
        {
        }

        private void student_FIO_TextChanged(object sender, EventArgs e)
        {
        }

        private void student_group_enter_TextChanged(object sender, EventArgs e)
        {
        }

        private void student_speciality_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Кнопка, по нажатии на котороую будет сгенирирован и добавлен случайный студент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Generate_student_Click(object sender, EventArgs e)
        {
            //Генерируем случайные данные нового пользователя
            try
            {
                Random rnd = new Random();
                string speciality = Student.random_specialities[rnd.Next(0, Student.random_specialities.Count - 1)];
                string FIO = Student.random_FIO[rnd.Next(0, Student.random_FIO.Count - 1)];
                string group = Student.random_Group[rnd.Next(0, Student.random_Group.Count - 1)];
                
                // Вызываем метод добавления студента
                logic.AddStudent(FIO, speciality, group);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            this.Close();
            Form1 formm = new Form1();
            formm.Show();
        }

        private void Add_student_view_Load(object sender, EventArgs e)
        {
        }
    }
}