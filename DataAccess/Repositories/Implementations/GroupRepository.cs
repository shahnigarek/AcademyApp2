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
            Dbcontexts.Groups.Add(entity);
            return entity;  
        }

        public void Delete(Group entity)
        {
            Dbcontexts.Groups.Remove(entity);
        }

        public void Update(Group entity)
        {
            var group = Dbcontexts.Groups.Find(g => g.ID == entity.ID);
            if (group != null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;
                group.ID = entity.ID;
            }

        }
        public Group Get(Predicate<Group> filter = null)
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

        public List<Group> GetAll(Predicate<Group> filter = null)
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

        void IRepository<Group>.Create(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
