using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Contexts;

namespace DataAccess.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group>

    {
        private static int id;

        public string MaxSize { get; set; }

        public Group Create(Group entity)
        {
            id++;
            entity.ID = id;
            try
            {
            Dbcontexts.Groups.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;  
        }

        public void Delete(Group entity)
        {
            try
            {
            Dbcontexts.Groups.Remove(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

        public void Update(Group entity)
        {
            try
            {
            var group = Dbcontexts.Groups.Find(g => g.ID == entity.ID);
            if (group != null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;
                group.ID = entity.ID;
            }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
                

        }
        public Group Get(Predicate<Group> filter = null)
        {
            try
            {
            if (filter == null)
            {
                return Dbcontexts.Groups[0];

            }
            else
            {
                return Dbcontexts.Groups.Find(filter);
            }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }


        }

        public List<Group> GetAll(Predicate<Group> filter = null)
        {
            try
            {

            if (filter == null)
            {
                return Dbcontexts.Groups;
            }

            else
            {
                return Dbcontexts.Groups.FindAll(filter);
            }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }


        }

        void IRepository<Group>.Create(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
