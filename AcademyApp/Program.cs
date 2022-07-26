using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;
using System;
namespace Manage
{
    class Program
    {
        static void Main()
        {
            StudentController _studentController = new StudentController();
            AdminController _adminController = new AdminController();
            GroupController _groupController = new GroupController();
            AdminRepository _adminRepository = new AdminRepository();
            TeacherController _teacherController = new TeacherController();
            TeacherRepository _teacherRepository = new TeacherRepository();

        Authentication: var admin = _adminController.Autenticate();


            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome , {admin.Username}");
                Console.WriteLine();

                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-Create a group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-Update a group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-Delete a group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-All groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-Get Group by name");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6-Create Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "7-Update Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "8-Delete Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "9-Get All Students By Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "10-Get Student By Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "11-Create a teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "12-Update teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "13-Delete teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "14-Get All Groups By Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "15-Add  Group To Teacher");
                     ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-Exit");


                    Console.WriteLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select option");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 15)
                        {
                            switch (selectedNumber)
                            {
                                case (int)Options.CreateGroup:
                                    _groupController.CreateGroup();
                                    break;
                                case (int)Options.UpdateGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)Options.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                case (int)Options.AllGroups:
                                    _groupController.AllGroups();
                                    break;
                                case (int)Options.GetGroupByName:
                                    _groupController.GetGroupName();
                                    break;
                                case (int)Options.CreateStudent:
                                    _studentController.CreateStudent();
                                    break;
                                case (int)Options.DeleteStudent:
                                    _studentController.DeleteStudent();
                                    break;
                                case (int)Options.GetAllStudentsByGroup:
                                    _studentController.GetAllStudentsByGroup();
                                    break;
                                case (int)Options.UpdateStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)Options.GetStudentByGroup:
                                    _studentController.GetStudentByGroup();
                                    break;
                                case (int)Options.CreateTeacher:
                                    _teacherController.CreateTeacher();
                                        break;
                                case (int)Options.Exit:
                                    _groupController.Exit();
                                    return;

                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                    }


                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Password or username were entered false,please try again");
                goto Authentication;
            }
        }
    }
}
































