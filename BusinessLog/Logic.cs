using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using Mod;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm;
using GalaSoft.MvvmLight.CommandWpf;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveCharts;
using LiveCharts.Wpf;
using DataAccessLayer;

namespace BusinessLog
{
    /// <summary>
    /// Связь между Model и Veiw
    /// </summary>

    public class Logic : INotifyPropertyChanged
    {
        // public EntityFrameworkRepository<Student> repository = new EntityFrameworkRepository<Student>();
        public IRepository<Student> repository { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        // public List<Student> students { get; set; } = new List<Student>(); 
        
        
        public static string path = "C:\\Users\\yaros\\RiderProjects\\WindowsFormsApp2\\WindowsFormsApp2\\table.txt";
        
        
        public  List<string> specialities_of_students { get; set; } = new List<string>();
        
        public List<int> count_of_specialities { get; set; } = new List<int>();
        
        public  ObservableCollection<string> specialities_of_students_for_WPF { get; set; } = new ObservableCollection<string>();
       
        public ChartValues<int> count_of_specialities_for_WPF { get; set; } = new ChartValues<int>();
        
        
        public ObservableCollection<Student> students_ { get; set; }
        private Student _newStudent;
        private Student selectedStudent;


        /// <summary>
        /// Создание экземпляра студента
        /// </summary>
        public Student newStudent
        {
            get { return _newStudent;}
            set
            {
                _newStudent = value;
                OnPropertyChanged("newStudent");
            }
        }
        /// <summary>
        /// Создание экземпляра текущего студента
        /// </summary>
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        
        public CommunityToolkit.Mvvm.Input.RelayCommand addStudentCommand { get; set; }
        public CommunityToolkit.Mvvm.Input.RelayCommand deleteStudentCommand { get; set; }
        public CommunityToolkit.Mvvm.Input.RelayCommand showHistogramm { get; set; }
        public CommunityToolkit.Mvvm.Input.RelayCommand generateStudentCommand { get; set; }

        public Logic(IRepository<Student> repository1)
        {
            repository = repository1;
            char[] a = {' '};

            students_ = new ObservableCollection<Student>{};
            newStudent = new Student();
            selectedStudent = new Student();
            addStudentCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(AddStudent);
            deleteStudentCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(DeleteStudent);
            generateStudentCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(GenerateStudent);
            showHistogramm = new CommunityToolkit.Mvvm.Input.RelayCommand(CreateGistogramm);

            foreach (var person in repository.GetBookList())
            {
                students_.Add(person);
            }
        }

        /// <summary>
        /// Конструктор класса, в котором заполняем данные для вывода в форме
        /// </summary>
        public Logic()
        {
            char[] a = {' '};

            students_ = new ObservableCollection<Student>{};
            newStudent = new Student();
            selectedStudent = new Student();
            addStudentCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(AddStudent);
            deleteStudentCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(DeleteStudent);
            generateStudentCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(GenerateStudent);
            showHistogramm = new CommunityToolkit.Mvvm.Input.RelayCommand(CreateGistogramm);

            foreach (var person in repository.GetBookList())
            {
                students_.Add(person);
            }
            // foreach (var person in Read_from_file())
            // {
            //     if (person.Length <= 2) continue;
            //     string[] current_person = person.Split(a);
            //     if (current_person.Length == 5)
            //     {
            //         students_.Add(
            //             new Student()
            //             {
            //                 Name = current_person[0] + " " + current_person[1] + " " + current_person[2],
            //                 Speciality = current_person[3],
            //                 Group = current_person[4]
            //             });
            //     }
            //     else if (current_person.Length == 4)
            //     {
            //         students_.Add(
            //             new Student()
            //             {
            //                 Name = current_person[0] + " " + current_person[1],
            //                 Speciality = current_person[2],
            //                 Group = current_person[3]
            //             });
            //     }
            //     else if (current_person.Length == 3)
            //     {
            //         students_.Add(
            //             new Student()
            //             {
            //                 Name = current_person[0],
            //                 Speciality = current_person[1],
            //                 Group = current_person[2]
            //             });
            //     }
            // }
        }

        /// <summary>
        /// Заполнение списков для формирования гистограммы
        /// </summary>
        private void CreateGistogramm()
        {
            Dictionary<string, int> specs = new Dictionary<string, int>();
           
            count_of_specialities_for_WPF.Clear();
            specialities_of_students_for_WPF.Clear();
            
            foreach (var person in students_)
            {
                if (specs.ContainsKey(person.Speciality))
                {
                    specs[person.Speciality]++;
                }
                else
                {
                    specs[person.Speciality] = 1;
                }
            
            }
            
            foreach (var speciality_key in specs.Keys)
            {
                specialities_of_students_for_WPF.Add(speciality_key);
                count_of_specialities_for_WPF.Add(specs[speciality_key]);
                
            }
            
        }

        /// <summary>
        /// Генерация данных случайного студента
        /// </summary>
        private void GenerateStudent()
        {
            Student st = new Student();
            Random rnd = new Random();
            newStudent.Name = Student.random_FIO[rnd.Next(0, Student.random_FIO.Count - 1)];
            newStudent.Speciality = Student.random_specialities[rnd.Next(0, Student.random_specialities.Count - 1)];
            newStudent.Group = Student.random_Group[rnd.Next(0, Student.random_Group.Count - 1)];
            repository.Create(newStudent);
            students_.Insert(0,newStudent);
            // students.Add(newStudent);
            Write_in_file(newStudent);
            newStudent = st;

        }

        /// <summary>
        /// Удаление конкретного студента по имеющимся данным
        /// </summary>
        private void DeleteStudent()
        {
            if (SelectedStudent == null)
            {
                return;
            }
            else
            {
                Console.WriteLine(SelectedStudent.ID);
                repository.Delete(SelectedStudent);
                DeleteStudent(SelectedStudent.Name, SelectedStudent.Speciality, SelectedStudent.Group);
                students_.Remove(SelectedStudent);
                
            }
        }

        /// <summary>
        /// Добавление студента в списки, а также проверка на заполненность данными
        /// </summary>
        private void AddStudent()
        {
            Console.WriteLine(newStudent.Group.Split().Length);
            if (newStudent.Name is null != true && newStudent.Speciality is null != true && newStudent.Group is null != true)
            {
                if (newStudent.Name.Split().Length >= 1 && newStudent.Speciality.Split().Length == 1 && newStudent.Group.Split().Length == 1)
                {  
                    Student st = new Student();
                    students_.Insert(0,newStudent);
                    // students.Add(newStudent);
                    Write_in_file(newStudent);
                    repository.Create(newStudent);
                    newStudent = st;
                    repository.Save();
                }
            }
            else { return; }
            
        }





        /// <summary>
        /// Очистка списков со специльностями
        /// </summary>
        public void Clear_specialitties(List<string> specialities_of_students, List<int> count_of_specialities)
        {
            specialities_of_students.Clear();
            count_of_specialities.Clear();
        }

        /// <summary>
        /// Метод подсчета и выделения специализаций пользователей
        /// В дальнейшем необходим для составления диаграммы
        /// </summary>
        public void Count_specialities()
        {
            char[] a = {' '};
            string[] text_from_file = Read_from_file();
        
            int person_pos = 0;
            
            // Выделение всех специализаций
            for (int i = 0; i < text_from_file.Length; i++)
            {
                
                if ((text_from_file[i] != ""))
                {
                    string[] split_the_text = text_from_file[i].Split(a);
                    string speciality1 = "";

                    if (split_the_text.Length == 5)
                    {
                        speciality1 = split_the_text[3];

                    }
                    else if (split_the_text.Length == 4)
                    {
                        speciality1 = split_the_text[2];
                    }
                    else if (split_the_text.Length == 3)
                    {
                        speciality1 = split_the_text[1];
                    }

                    if (specialities_of_students.Contains(speciality1) == false)
                    {
                        specialities_of_students.Add(speciality1);
                        count_of_specialities.Add(0);
                    }
                }
            }
            
            // Подсчет всех специализаций
            for (int i = 0; i < specialities_of_students.Count; i++)
            {
                for (int j = 0; j < text_from_file.Length; j++)
                {
                    if ((text_from_file[j] != "") && text_from_file[j] != " ")
                    {
                        string[] split_the_text = text_from_file[j].Split(a);
                        string speciality1 = "";
                        if (split_the_text.Length == 5)
                        {
                            speciality1 = split_the_text[3];

                        }
                        else if (split_the_text.Length == 4)
                        {
                            speciality1 = split_the_text[2];
                        }
                        else if (split_the_text.Length == 3)
                        {
                            speciality1 = split_the_text[1];
                        }
                        if (speciality1 == specialities_of_students[i])
                        {
                            count_of_specialities[i] += 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Добавление нового студента в listbox и в файл
        /// </summary>
        /// <param name="name">Имя студента</param>
        /// <param name="speciality">Специальность студента</param>
        /// <param name="group">Группа студента</param>
        public  void AddStudent(string name, string speciality, string group)
        {
            Student person = new Student();
            person.Name = name;
            person.Group = group;
            person.Speciality = speciality;
            repository.Create(person);
            // students.Add(person);
            Write_in_file(person);
            
        }
        /// <summary>
        /// Метод удаления выбранного пользователя из файла и списка
        /// </summary>
        /// <param name="name"> Получаем имя пользователя</param>
        /// <param name="speciality"> Получаем специальность пользователя</param>
        /// <param name="group">Получаем группу пользователя</param>
        public  void DeleteStudent(string name, string speciality, string group)
        {
            char[] a = {' '};
            string[] text_from_file = Read_from_file();
            List<string> text_to_file = new List<string>();
        
            int person_pos = 0;

            // if (students.Count != 0)
            // {
            //     // Цикл для удаления конкретного пользователя их списка
            //     for (int i = 0; i < students.Count; i++)
            //     {
            //         if ((students[i].Name == name) && (students[i].Group == group) &&
            //             (students[i].Speciality == speciality))
            //         {
            //             person_pos = i;
            //             break;
            //         }
            //     }
            //     students.RemoveAt(person_pos);
            // }
            //
            // Цикл обработки и составления нового списка на передачу после удалеия пользователя
            for (int i = 0; i < text_from_file.Length; i++)
            {
                if (text_from_file[i].Length > 2 )
                {
                    string name1 = "";
                    string speciality1 = "";
                    string group1 = "";
                    string[] split_the_text = text_from_file[i].Split(a);
                    if (split_the_text.Length == 5){
                        name1 = split_the_text[0] + " " + split_the_text[1] + " " + split_the_text[2];
                        speciality1 = split_the_text[3];
                        group1 = split_the_text[4];
                    }

                    
                    if ((name1 == name) && (group1 == group) &&
                        (speciality1 == speciality) && (person_pos < 1))
                    {
                        person_pos++;
                    }
                    else
                    {
                        text_to_file.Add(name1 + " " + speciality1 + " " + group1 + "\n");
                    }
                }

                
            }

            Student st = new Student(name, speciality, group);
            repository.Delete(st);
            File.WriteAllText(path,string.Empty);
            foreach (var line in text_to_file)
            {
                File.AppendAllText(path, line);
            }
        }

        /// <summary>
        /// Метод простой записи в файл введенного пользователя 
        /// </summary>
        /// <param name="person">объект созданного пользователя</param>
        public void Write_in_file(Student person)
        {
                File.AppendAllText(path, person.Name + " " + person.Speciality + " " + person.Group +"\n");
        }

        /// <summary>
        /// Метод считывания информацаии из файла
        /// </summary>
        /// <returns> Возвращает список с информацией по каждому пользователю в массива строк</returns>
        public string[] Read_from_file()
        {
            using (FileStream fsSource = new FileStream(path,
                       FileMode.Open, FileAccess.Read))
            {

                // Read the source file into a byte array.
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                char[] delimiterChars = { ',', '.', ':', '\n'};
                return Encoding.UTF8.GetString(bytes).Split(delimiterChars);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


    }
}