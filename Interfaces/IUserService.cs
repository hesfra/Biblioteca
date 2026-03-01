using Biblioteca.Entities;

namespace Biblioteca.Interfaces;

public interface IUserService
{

    bool Create(string name, string email);
    
    bool Update(string id, UpdateUserRequest user);


    User? GetById(string id);

    User? GetByName(string name);

    User? GetByEmail(string email);

    List<User> GetAll();


    void Inactivate(string id);

}
