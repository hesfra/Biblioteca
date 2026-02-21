using Biblioteca.Entities;
using Biblioteca.Interfaces;
using Biblioteca.Storages.Interfaces;
using ILogger = Biblioteca.Commons.Logging.ILogger;

namespace Biblioteca.Services;

public class UserService(IUserStorage userStorage, ILogger logger): Interfaces.IUserRepository
{
    private readonly IUserStorage _UserStorage = userStorage;
    private readonly ILogger _Logger = logger;
    public bool Create(User user)
    {
        try
        {
            _Logger.Info($"Attempting to create user: {user.Name}");
            var result = _UserStorage.Create(user);
            _Logger.Info($"Successfully created user: {user.Name}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"Error creating user: {user.Name}", ex);
            return false;
        }
    }

    public bool Update(string id, User user)
    {
        try
        {   
            _Logger.Info($"Attempting to update user with ID: {id}");
            var result = _UserStorage.Update(id, user);
            _Logger.Info($"Successfully updated user with ID: {id}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"Error updating user with ID: {id}", ex);
            return false;
        }
    }

    public User? GetById(string id)
    {
        try
        {   
            _Logger.Info($"Attempting to retrieve user by ID: {id}");
            var result = _UserStorage.GetById(id);
            _Logger.Info($"Successfully retrieved user by ID: {id}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"Error retrieving user by ID: {id}", ex);
            return null;
        }
    }

    public User? GetByName(string name)
    {
        try
        {
            _Logger.Info($"Attempting to retrieve user by name: {name}");
            var result = _UserStorage.GetByName(name);
            _Logger.Info($"Successfully retrieved user by name: {name}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"Error retrieving user by name: {name}", ex);
            return null;
        }
    }

    public User? GetByEmail(string email)
    {
        try
        {
            _Logger.Info($"Attempting to retrieve user by email: {email}");
            var result = _UserStorage.GetByEmail(email);
            _Logger.Info($"Successfully retrieved user by email: {email}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"Error retrieving user by email: {email}", ex);
            return null;
        }
    }

    public List<User> GetAll()
    {
        try
        {
            _Logger.Info("Attempting to retrieve all users");
            var result = _UserStorage.GetAll();
            _Logger.Info("Successfully retrieved all users");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error("Error retrieving all users", ex);
            return [];
        }
    }

    public void Inactivate(string id)
    {
        try
        {
            _Logger.Info($"Attempting to inactivate user with ID: {id}");
            _UserStorage.Inactivate(id);
            _Logger.Info($"Successfully inactivated user with ID: {id}");
        }
        catch (Exception ex)
        {
            _Logger.Error($"Error inactivating user with ID: {id}", ex);
        }
    }



}