using Biblioteca.Entities;

namespace Biblioteca.Storages.Interfaces;

public interface IUserStorage
{
    bool Create(User user);

    User? Update(string id, UpdateUserRequest updateRequest);

    User? GetById(string id);

    User? GetByName(string name);

    User? GetByEmail(string email);

    List<User> GetAll();

    void Inactivate(string id);
}
