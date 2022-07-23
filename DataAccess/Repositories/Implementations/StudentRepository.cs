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
    public class StudentRepository : IRepository<Student>
    {
        private static int id;
        public Student Create(Student entity)
        {

            id++;
            entity.ID = id;
            Dbcontexts.Students.Add(entity);
            return entity;  

        }

        public void Delete(Student entity)
        {
            Dbcontexts.Students.Remove(entity);
        }

        public Student Get(Predicate<Student> filter = null)
        {
           if(filter == null)
            {
                return Dbcontexts.Students[0];
            }
            else
            {
                return Dbcontexts.Students.Find(filter);
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
          if(filter == null)
            {
                return Dbcontexts.Students;

            }
            else
            {
                return Dbcontexts.Students.FindAll(filter);
            }
        }

        public void Update(Student entity)
        {
         var student=Dbcontexts.Students.Find(s => s.ID == entity.ID);
            if(student != null)
            {
                student.ID = entity.ID;
                student.ID = entity.ID;
                student.Surname = entity.Surname;
                student.Age = entity.Age;
            }
        }

        void IRepository<Student>.Create(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
