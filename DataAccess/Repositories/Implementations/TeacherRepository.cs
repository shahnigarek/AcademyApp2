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
    public class TeacherRepository : IRepository<Teacher>
    {
        private static int id;
        public Teacher  Create(Teacher entity)
        {

            id++;
            entity.ID = id;
            try
            {
                Dbcontexts.Teacher.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;

        }

        public void Delete(Teacher entity)
        {
            try
            {
                Dbcontexts.Teacher.Remove(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }

        }

        public Teacher Get(Predicate<Teacher> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Teacher[0];
                }
                else
                {
                    return Dbcontexts.Teacher.Find(filter);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Teacher> GetAll(Predicate<Teacher> filter = null)
        {
            try
            {


                if (filter == null)
                {
                    return Dbcontexts.Teacher;

                }
                else
                {
                    return Dbcontexts.Teacher.FindAll(filter);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Teacher entity)
        {

            try
            {
                var teacher = Dbcontexts.Students.Find(t => t.ID == entity.ID);
                if (teacher != null)
                {
                    
                    teacher.ID = entity.ID;
                    teacher.Surname = entity.Surname;
                    teacher.Age = entity.Age;
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
         

        void IRepository<Teacher>.Create(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
