using System.Collections.Generic;
using DowJones.Models;
using System.Linq;
using DowJones.DAL;

namespace DowJones.BLL
{
    public class UsersBLL
    {
        private readonly UnitOfWork unitOfWork;

        public UsersBLL(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<User> GetUsers()
        {
            return unitOfWork.UsersRepository.GetAll().ToList();
        }

        public User GetUserByEmail(string email)
        {
            return unitOfWork.UsersRepository.Get(i=>i.Email==email).FirstOrDefault();
        }
    }
}
