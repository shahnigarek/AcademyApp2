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

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Teacher-{tutor.Name} with surname-{tutor.Surname} and with age-{tutor.Age} was successufully created");
            

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
            }
            
            

        }
    }
}


