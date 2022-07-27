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
    public class StudentController
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        Student student = new Student();

        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }

        public void CreateStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter student name");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter student surname");
                string surname = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter student age");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);

            AllGroupsList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All groups");

                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, group.Name);
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter group name");
                string groupName = Console.ReadLine();

                var dbgroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (dbgroup != null)
                {
                    if (dbgroup.MaxSize > dbgroup.CurrentSize)
                    {
                        var student = new Student
                        {
                            Name = name,
                            Age = studentAge,
                            Surname = surname,
                            Group = dbgroup
                        };
                        dbgroup.CurrentSize++;

                        _studentRepository.Create(student);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{student.ID},Name;{student.Name},Surname:{student.Surname},Age:{student.Age}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Group is full,group's maxsize:{dbgroup.MaxSize}");

                    }




                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including group doesn't exist");
                    goto AllGroupsList;

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please create group before inputing info about student");
            }


        }
        public void DeleteStudent()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the student you want to delete ");
            string ID = Console.ReadLine();
            int Id;

            bool result = int.TryParse(ID, out Id);

            var student = _studentRepository.Get(s => s.ID == Id);

            if (student != null)
            {
                _studentRepository.Delete(student);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $" student with ID:{student.ID} is deleted");
               
                

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Student with this ID  doesn't exist");
            }
        }
        public void GetAllStudentsByGroup()
        {
            var groups = _groupRepository.GetAll();

        GroupAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All groups");

            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, group.Name);
            }

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please,enter group name");
            string groupName = Console.ReadLine();

            var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {
                var groupStudents = _studentRepository.GetAll(s => s.Group.ID == dbGroup.ID);

                if (groupStudents.Count != 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All students of the group:");
                    foreach (var groupStudent in groupStudents)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{groupStudent.Name},{groupStudent.Surname},{groupStudent.Age}");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no student in the given group:{dbGroup.Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The entered group doesn't exist,please try again");
                goto GroupAllList;
            }
        }
        public  void UpdateStudent()
        {
            GetAllStudentsByGroup();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter student ID");
            string ID = Console.ReadLine();
            int Id;
            bool result = int.TryParse(ID, out Id);

            var studentid = _studentRepository.Get(s => s.ID == Id);
            if (studentid != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new student name:");
                string newname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new student surname:");
                string newsurname = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new student age:");
                string newage = Console.ReadLine();
                byte age;
                 result = byte.TryParse(newage, out age);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new group name");
                string newGroupName= Console.ReadLine();

                if (studentid.Group.Name.ToLower() == newGroupName)
                {

                    studentid.Name = newname;
                    studentid.Surname = newsurname;
                    studentid.Age = age;
                    _studentRepository.Update(studentid);



                }
                else
                {
                    studentid.Name = newname;
                    studentid.Surname = newsurname;
                    studentid.Age = age;
                    
                    var newgroup = _groupRepository.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                    if (newgroup!=null)
                    {
                        studentid.Group.CurrentSize--;
                        studentid.Group = newgroup;
                    studentid.Group.CurrentSize++;
                    _studentRepository.Update(studentid);

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right group name");
                        

                    }
                }
            }
              else
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right ID");
                }





        }
         public void GetStudentByGroup()
        {
            var groups = _groupRepository.GetAll();

        ConsoleHelper .WriteTextWithColor(ConsoleColor.DarkMagenta, "All groups");

            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, group.Name);
            }

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please,enter group name you want to getstudent from");
            string groupName = Console.ReadLine();

            var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter a student name");
                string name = Console.ReadLine();
                var studentName = _studentRepository.Get(s => s.Name.ToLower() == name.ToLower());
                if (studentName != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"Studentname is {name},Studentsurname is {student.Surname},StudentAge is{student.Age}");
                }

                

            } 
        }
        
       
       



    }
}







