using Core.Entities;
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
            ConsoleHelper.WriteTextWithColor()
        }
    }
}
