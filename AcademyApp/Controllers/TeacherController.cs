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
        Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter teacher age");
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
                var tutor = _teacherRepository.Create(teacher);

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Teacher-{tutor.Name},tutor's ID-{tutor.ID} with surname-{tutor.Surname} and with age-{tutor.Age} was successufully created");


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                goto Age;
            }



        }
        public void DeleteTeacher()
        {
            GetAll();
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
            GetAll();
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
            Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new teacher's age:");
                string newage = Console.ReadLine();
                byte age;
                result = byte.TryParse(newage, out age);
                if (result)
                {

                    var newtutor = new Teacher
                    {
                        ID = tutorid.ID,
                        Name = newname,
                        Surname = newsurname,
                        Age = age
                    };
                    _teacherRepository.Update(newtutor);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{tutorid.Name},Surname:{tutorid.Surname},Age:{newtutor.Age} is updated to Name: {newtutor.Name}, Surname: {newtutor.Surname},Age:{newtutor.Age} ");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
                    goto Age;
                }
            }

            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct ID of teacher");
            }

        }
        public void GetAll()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All teacher list");

                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.ID}, Fullname - {teacher.Name} {teacher.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no teacher,please create it ");
            }
        }
        public void AddGroupToTeacher()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                var teachers = _teacherRepository.GetAll();
                if (teachers.Count > 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teachers list");

                    foreach (var teacher in teachers)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.ID}, Fullname - {teacher.Name} {teacher.Surname}");
                    }

                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher id:");
                    string id = Console.ReadLine();

                    int tutorID;
                    var result = int.TryParse(id, out tutorID);

                    if (result)
                    {
                        var teacher = _teacherRepository.Get(t => t.ID == tutorID);
                        if (teacher != null)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All groups list");

                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id - {group.ID}, Name - {group.Name}");
                            }

                          GroupID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group id:");
                            string groupid = Console.ReadLine();
                            int groupID;
                            result = int.TryParse(groupid, out groupID);
                            if (result)
                            {
                                var group = _groupRepository.Get(g => g.ID == groupID);
                                if (group != null)
                                {
                                    if (group.Teacher != null)
                                    {
                                        teacher.Groups.Add(group);
                                        group.Teacher = teacher;
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{group.Name} is successfully added to {teacher.Name}");
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"This group has already teacher - {group.Teacher.Name} {group.Teacher.Surname}");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no group with this ID,please enter another one ");
                                    goto GroupID;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter id in correct form");
                                goto GroupID;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter id in correct form");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There isn't any  teacher");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create a group before adding group to teacher");
            }
        }
        public void GetAllGroupsByTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teachers list");

                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.ID}, Fullname - {teacher.Name} {teacher.Surname}");
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher id:");
                string id = Console.ReadLine();

                int teacherId;
                var result = int.TryParse(id, out teacherId);

                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.ID == teacherId);
                    if (teacher != null)
                    {
                        var groups = _groupRepository.GetAll(g => g.Teacher != null ? g.Teacher.ID == teacher.ID : false);
                        if (groups.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "The groups of teacher");

                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {group.ID}, Name - {group.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher has no group");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no teacher with this ID,please try again :)");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter id in correct form");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There isn't any teacher");
            }
        }




    }
}









