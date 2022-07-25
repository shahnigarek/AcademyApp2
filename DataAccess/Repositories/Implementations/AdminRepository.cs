using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class AdminRepository:IRepository<Admin>
    {
        private static int id;
        public Admin Create(Admin entity)
        {

            id++;
            entity.ID = id;
            Dbcontexts.Admins.Add(entity);
            return entity;

        }

        public void Delete(Admin entity)
        {
            Dbcontexts.Admins.Remove(entity);
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return Dbcontexts.Admins[0];
            }
            else
            {
                return Dbcontexts.Admins.Find(filter);
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return Dbcontexts.Admins;

            }
            else
            {
                return Dbcontexts.Admins.FindAll(filter);
            }
        }

        public void Update(Admin entity)
        {
            var admin = Dbcontexts.Admins.Find(a => a.ID == entity.ID);
            if (admin != null)
            {
                
                admin.Username = entity.Username;
                admin.Password = entity.Password;   

            }
        }

        void IRepository<Admin>.Create(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}

