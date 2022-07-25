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
    public   class AdminController
    {
        private AdminRepository _adminRepository;
        public AdminController()
        {
            _adminRepository = new AdminRepository();

        }
        public Admin Autenticate()
        {
            AdminAuthentication: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter username");
            string username = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter password");
            string password = Console.ReadLine();

            var admin = _adminRepository.Get(a => a.Username.ToLower() == username.ToLower() && PasswordHasher.Decrypt(a.Password) == password);

            return admin;

        }
    }
}
