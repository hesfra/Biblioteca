using Biblioteca.Entities;

namespace Biblioteca.Storages.Interfaces;

public interface IUserStorage
{
    bool Create(User user);

    bool Update(string id, User user);

    User? GetById(string id);

    User? GetByName(string name);

    User? GetByEmail(string email);

    List<User> GetAll();

    void Inactivate(string id);
}
