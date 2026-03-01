using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Entities;
using Biblioteca.Storages.Interfaces;
namespace Biblioteca.Storages.InMemory
{

    public class UserStorage : IUserStorage
    {
        private List<User> _users = new();

        public bool Create(User user)
        {
            _users.Add(user);
            return true;
        }

        public User? GetById(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
        public User? GetByName(string name)
        {
            return _users.FirstOrDefault(u => u.Name == name);
        }
        public User? GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAll()
        {
            return _users.ToList();
        }

        public User? Update(string id, UpdateUserRequest updateRequest)
        {
            var user = GetById(id);
            if (user != null)
            {
                user.Update(updateRequest.Email ?? user.Email);
            }
            return user;
        }

        public void Inactivate(string id)
        {
            var user = GetById(id);
            if (user != null)
            {
                user.Inactivate(); // Inativa o usuário
            }
        }
    }
}