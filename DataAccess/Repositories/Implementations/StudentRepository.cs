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
            try
            {
            Dbcontexts.Students.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;  

        }

        public void Delete(Student entity)
        {
            try
            {
            Dbcontexts.Students.Remove(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

        public Student Get(Predicate<Student> filter = null)
        {
            try
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
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            try
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
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Student entity)
        {
            try
            {
         var student=Dbcontexts.Students.Find(s => s.ID == entity.ID);
            if(student != null)
            {
                    student.ID = entity.ID; 
                student.Surname = entity.Surname;
                student.Age = entity.Age;
            }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

        void IRepository<Student>.Create(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
