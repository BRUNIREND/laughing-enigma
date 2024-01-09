using System;
using BusinessLog;
using Ninject;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            Logic logic = ninjectKernel.Get<Logic>();
            Console.WriteLine("Добро пожаловать в Decanat Pro Max ++++++");
            Console.WriteLine("Выберите предложенное действие");
            string user_input = "";
            while (true)
            {
                
                char[] a = new[] { ' ' }; 
                string[] text_from_file = logic.Read_from_file();
                string user_input_student_FIO = "";
                string user_input_student_group = "";
                string user_input_student_specialisation = "";
                
                Console.WriteLine(
                    "1 - Отобразить список всех студентов\n" +
                    "2 - Добавить нового студента\n" +
                    "3 - Удалить определенного студента\n" +
                    "4 - Вывести гистограмму\n" +
                    "0 - Выход из программы\n"
                    );
                Console.Write("Ввод >> ");
                user_input = Console.ReadLine();
                switch (user_input)
                {
                    case "0":
                        Console.WriteLine("Спасибо, что пользовались программой, хорошего дня)");
                        Environment.Exit( 0 );
                        break;
                    case "1":
            
                        for (int i = 0; i < text_from_file.Length; i++)
                        {
                
                            if ((text_from_file[i] != ""))
                            {
                                Console.WriteLine((i + 1).ToString() + ": " + text_from_file[i]);
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите ФИО");
                        Console.Write("Ввод >> ");

                        user_input_student_FIO = Console.ReadLine();
                        string[]user_input_student_FIO_split = user_input_student_FIO.Split(a);
                        if (user_input_student_FIO_split.Length < 3)
                        {
                            Console.WriteLine("Sorry, but this FIO is incorrect.");
                            break;
                        }

                        Console.WriteLine("Введите Специализацию");
                        Console.Write("Ввод >> ");

                        user_input_student_specialisation = Console.ReadLine();
                        if (user_input_student_specialisation == "" || user_input_student_specialisation == " ")
                        {
                            Console.WriteLine("Sorry, but this speciality is incorrect.");
                            break;
                        }
                        Console.WriteLine("Введите группу");
                        Console.Write("Ввод >> ");

                        user_input_student_group = Console.ReadLine();
                        
                        if (user_input_student_group == "" || user_input_student_group == " ")
                        {
                            Console.WriteLine("Sorry, but this group is incorrect.");
                            break;
                        }
                        
                        logic.AddStudent(user_input_student_FIO, user_input_student_specialisation,
                            user_input_student_group);
                        Console.WriteLine("Студент успешно добавлен!");
                        break;
                    case "3":
                        for (int i = 0; i < text_from_file.Length; i++)
                        {
                            
                            if ((text_from_file[i] != ""))
                            {
                                Console.WriteLine((i + 1).ToString() + ": " + text_from_file[i]);
                            }
                        }
                        Console.WriteLine("Выберите номер: ");
                        Console.Write("Ввод: ");
                        int user_input_for_delete = 10000;
                        try
                        {
                            user_input_for_delete = int.Parse(Console.ReadLine());

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Enter incorrect value");
                            break;
                        }

                        if (user_input_for_delete <= text_from_file.Length - 1 && user_input_for_delete >= 0)
                        {
                            string[] text_for_split = text_from_file[user_input_for_delete - 1].Split(a);
                            user_input_student_FIO = text_for_split[0] + " " + text_for_split[1] + " " + text_for_split[2];
                            Console.WriteLine(user_input_student_FIO);
                            user_input_student_specialisation = text_for_split[3];
                            user_input_student_group = text_for_split[4];
                            logic.DeleteStudent(user_input_student_FIO, user_input_student_specialisation, user_input_student_group);
                            Console.WriteLine("Студент успешно удален!");

                        }
                        else
                        {
                            Console.WriteLine("Oops, this student is not in list");
                        }

                        break;
                    case "4":
                        // Метод подсчета текущего количества различных специльностей
                        logic.Count_specialities();
            
                        // Получаем список количества специализаций и сами специализации
                        var daysOfWeek = logic.specialities_of_students;
                        var numberOfVisitors = logic.count_of_specialities;
                        if (daysOfWeek.Count != 0 & numberOfVisitors.Count != 0)
                        {
                            for (int i = 0; i < daysOfWeek.Count; i++)
                            {
                                Console.Write(daysOfWeek[i] + ": ");
                                for (int j = 0; j < numberOfVisitors[i]; j++) {
                                    Console.Write("|" );
            
                                }
                                Console.WriteLine();
            
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, but specialization is empty");
                        }
                        logic.Clear_specialitties(daysOfWeek, numberOfVisitors);
                        break;
                }
            }
        }
    }
}