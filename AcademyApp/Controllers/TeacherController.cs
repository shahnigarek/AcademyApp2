using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class TeacherController
    {
        private TeacherRepository _teacherRepository;
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        Student student = new Student();
        Teacher teacher = new Teacher();

        public TeacherController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
            _teacherRepository = new TeacherRepository();
        }
        public void CreateTeacher()
        {
         
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter teacher name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter teacher surname");
            string surname = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter teacher age");
            string age = Console.ReadLine();
            byte teacherAge;
            bool result = byte.TryParse(age, out teacherAge);
            if (result)
            {

            Teacher teacher = new Teacher
            {
                Name = name,
                Age = teacherAge,
                Surname = surname
            };
            var tutor= _teacherRepository.Create(teacher);

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Teacher-{tutor.Name},tutor's ID-{tutor.ID} with surname-{tutor.Surname} and with age-{tutor.Age} was successufully created");
            

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
            }
            
            

        }
        public void DeleteTeacher()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the teacher you want to delete ");
            string ID = Console.ReadLine();
            int Id;

            bool result = int.TryParse(ID, out Id);

            var tutor = _teacherRepository.Get(t => t.ID == Id);

            if (tutor != null)
            {
                _teacherRepository.Delete(tutor);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Teacher with ID:{tutor.ID} is deleted");



            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher with this ID  doesn't exist");
            }

        }
        public void UpdateTeacher()
        {
          
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter teacher's ID");
            string ID = Console.ReadLine();
            int Id;
            bool result = int.TryParse(ID, out Id);

            var tutorid = _teacherRepository.Get(t => t.ID == Id);
            if (tutorid != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new teacher's name:");
                string newname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new teacher's surname:");
                string newsurname = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new teacher's age:");
                string newage = Console.ReadLine();
                byte age;
                result = byte.TryParse(newage, out age);
                if(result)
                {
                   
                        var newtutor= new Teacher
                        {
                            ID = tutorid.ID,
                            Name = newname,
                           Surname=newsurname,
                           Age=age
                        };
                        _teacherRepository.Update(newtutor);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{tutorid.Name},Surname:{tutorid.Surname},Age:{newtutor.Age} is updated to Name: {newtutor.Name}, Surname: {newtutor.Surname},Age:{newtutor.Age} ");
                }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
                    }
            }

                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct ID of teacher");
                }

        }
        
    }
}

                    







