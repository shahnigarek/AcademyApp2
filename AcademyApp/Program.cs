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
            StudentRepository _studentRepository = new StudentRepository();
            GroupController _groupController = new GroupController();
            GroupRepository _groupRepository = new GroupRepository();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Welcome");
            Console.WriteLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please,choose 1 for group or 2 for student");
            string number = Console.ReadLine();
            if (number == "1")
            {
                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-Create a group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-Update a group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-Delete a group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-All groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-Get Group by name");
                  
                    Console.WriteLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select option");
                    number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber == 1 && selectedNumber <= 5)
                        {
                            switch (selectedNumber)
                            {
                                case (int)Options.CreateGroup:
                                    _groupController.CreateGroup();
                                    break;
                                case (int)Options.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                case (int)Options.UpdateGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)Options.AllGroups:
                                    _groupController.AllGroups();
                                    break;
                                case (int)Options.GetGroupByName:
                                    _groupController.GetGroupName();
                                    break;
                             
                            }

                        }
                    }
                }

            }
            else if (number == "2")
            {
                while (true)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-Create Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-Update Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-Delete Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-GetAll Students By Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-Get Student By Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-Exit");
                    Console.WriteLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select option");
                    number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber == 1 && selectedNumber <= 4)
                        {
                            switch (selectedNumber)
                            {
                                case (int)Options2.CreateStudent:
                                    _studentController.CreateStudent();
                                    break;
                                case (int)Options2.DeleteStudent:
                                    _studentController.DeleteStudent();
                                    break;
                                case (int)Options2.GetAllStudentsByGroup:
                                    _studentController.GetAllStudentsByGroup();
                                    break;
                                case (int)Options2.UpdateStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)Options2.GetStudentByGroup:
                                    _studentController.GetStudentByGroup();
                                    break;
                                case (int)Options2.Exit:
                                    _studentController.Exit();
                                    return;
                            }
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter 1 or 2");
                    }
                }

            }


        }

    }

}

   







                                   

                                    







