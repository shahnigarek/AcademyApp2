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
    public class GroupController
    {
        private GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }

        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter group name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group == null)
            {
            MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter group maxsize");
                string size = Console.ReadLine();
                int maxsize;
                bool result = int.TryParse(size, out maxsize);
                if (result)
                {

                    Group newgroup = new Group
                    {
                        Name = name,
                        MaxSize = maxsize


                    };
                    var createdGroup = _groupRepository.Create(newgroup);

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} with maxsize-{createdGroup.MaxSize} was successufully created");

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please,enter right number!!");
                    goto MaxSize;

                }


            }
        }
        #endregion CreateGroup
        #region AllGroups
        public void AllGroups()
        {

            var groups = _groupRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All groups");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name:{group.Name},maxSize:{group.MaxSize}");
            }
        }
        #endregion AllGroups
        #region Exit
        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thanks for using application");

        }
        #endregion Exit
        #region GetGroupName
        public void GetGroupName()
        {
            AllGroups();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name");
            string name = Console.ReadLine();

            var group = _groupRepository.Get((g => g.Name.ToLower() == name.ToLower()));
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name;{group.Name},maxSize:{group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }

        }
        #endregion GetGroupName
        #region UpdateGroup
        public void UpdateGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All groups");
                foreach (var dbgroup in groups)
                {
                    Console.WriteLine($"ID-{dbgroup.ID},Name-{dbgroup.Name}");

                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group ID");
                int choosenid;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out choosenid);
                if (result)
                {
                    var group = _groupRepository.Get(g => g.ID == choosenid);

                    if (group != null)
                    {
                        int OldSize = group.MaxSize;
                        string oldName = group.Name;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new group name:");
                        string newName = Console.ReadLine();

                       maxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new group maxSize:");
                        string newsize = Console.ReadLine();

                        int maxSize;
                        result = int.TryParse(newsize, out maxSize);

                        if (result)
                        {
                            var newGroup = new Group
                            {
                                ID = group.ID,
                                Name = newName,
                                MaxSize = maxSize
                            };
                            _groupRepository.Update(newGroup);

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{oldName}, Max size: {OldSize} is updated to Name: {newGroup.Name}, Max size : {newGroup.MaxSize} ");


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right group maxSize");
                            goto maxSize;
                        }


                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group name");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct ID");
                    goto Id;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");

            }
        }
        #endregion UpdateGroup
        #region DeleteGroup
        public void DeleteGroup()
        
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");
                foreach (var dbGroup in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"ID-{dbGroup.ID},Name-{dbGroup.Name}");

                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group ID");
                int choosenid;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out choosenid);
                if (result)
                {
                    var group = _groupRepository.Get(g => g.ID == choosenid);
                    if (group != null)
                    {

                        string name = group.Name;
                        _groupRepository.Delete(group);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                    }
                }

            }
        }
        #endregion

    }


}


       
 












   





 





