using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace Mod
{
   
    public class Student: INotifyPropertyChanged, IDomainObject
    {
        public int ID { get; set; }
        private string name;
        private string speciality;
        private string group;

        /// <summary>
        /// Конструктор класса Student для WPF
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// Инициализация данных при создании экземпляра
        /// </summary>
        /// <param name="name">Имя студента</param>
        /// <param name="spec">Специальность</param>
        /// <param name="group">Группа</param>
        public Student(string name, string spec, string group)
        {
            Name = name;
            Speciality = spec;
            Group = group;
        }

        
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        
        public string Speciality
        {
            get { return speciality; }
            set
            {
                speciality = value;
                OnPropertyChanged("Speciality");
            }
        }
        
        public string Group
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
       /// <summary>
       /// Реализация интерфейса INotifyPropertyChanged
       /// </summary>
       /// <param name="prop">Передаваемое свойство</param>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
        
        public static List<string> random_specialities  = new List<string>()
        {
            "ИСИТ", "ПИ", "ИБ", "ПИ2", "КБ"
        };
        public static List<string> random_FIO  = new List<string>()
        {
            "Прокофьев Валерий Семенович","Козлов Валерий Игоревич","Стрыколо Дмитрий Валентинович","Каров Матвей Семенович",
        };
        public static List<string> random_Group  = new List<string>()
        {
            "КИ22-11","КИ22-12","КИ23-17","КИ20-15","КИ23-16","КИ19-17",
        };
    }
}