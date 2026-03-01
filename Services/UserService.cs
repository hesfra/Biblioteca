using Biblioteca.Entities;
using Biblioteca.Interfaces;
using Biblioteca.Storages.Interfaces;
using ILogger = Biblioteca.Commons.Logging.ILogger;
using Biblioteca.Commons;
namespace Biblioteca.Services;

public class UserService(IUserStorage userStorage, ILogger logger): Interfaces.IUserService
{
    private readonly IUserStorage _UserStorage = userStorage;
    private readonly ILogger _Logger = logger;
    public bool Create(string name, string email)
    {
        try
        {
            var user = new User(
                IDCreator.NewId(),
                name,
                email,
                DateTime.UtcNow,
                true
            );
            _Logger.Info($"[UserService] Attempting to create user: {user.Name}");
            var result = _UserStorage.Create(user);
            _Logger.Info($"[UserService] Successfully created user: {user.Name}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"[UserService] Error creating user: {name}", ex);
            return false;
        }
    }

    public bool Update(string id, UpdateUserRequest user)
    {
        try
        {   
            _Logger.Info($"[UserService] Attempting to update user with ID: {id}");
            if(user.Email != null)
            {
            var result = _UserStorage.Update(id, user);
            _Logger.Info($"[UserService] Successfully updated user with ID: {id}");
            return true;    
            }
            _Logger.Info($"[UserService] No update performed for user with ID: {id} as no valid fields were provided");
            return false;
        }
        catch (Exception ex)
        {
            _Logger.Error($"[UserService] Error updating user with ID: {id}", ex);
            return false;
        }
    }

    public User? GetById(string id)
    {
        try
        {   
            _Logger.Info($"[UserService] Attempting to retrieve user by ID: {id}");
            var result = _UserStorage.GetById(id);
            _Logger.Info($"[UserService] Successfully retrieved user by ID: {id}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"[UserService] Error retrieving user by ID: {id}", ex);
            return null;
        }
    }

    public User? GetByName(string name)
    {
        try
        {
            _Logger.Info($"[UserService] Attempting to retrieve user by name: {name}");
            var result = _UserStorage.GetByName(name);
            _Logger.Info($"[UserService] Successfully retrieved user by name: {name}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"[UserService] Error retrieving user by name: {name}", ex);
            return null;
        }
    }

    public User? GetByEmail(string email)
    {
        try
        {
            _Logger.Info($"[UserService] Attempting to retrieve user by email: {email}");
            var result = _UserStorage.GetByEmail(email);
            _Logger.Info($"[UserService] Successfully retrieved user by email: {email}");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error($"[UserService] Error retrieving user by email: {email}", ex);
            return null;
        }
    }

    public List<User> GetAll()
    {
        try
        {
            _Logger.Info("[UserService] Attempting to retrieve all users");
            var result = _UserStorage.GetAll();
            _Logger.Info("[UserService] Successfully retrieved all users");
            return result;
        }
        catch (Exception ex)
        {
            _Logger.Error("[UserService] Error retrieving all users", ex);
            return [];
        }
    }

    public void Inactivate(string id)
    {
        try
        {
            _Logger.Info($"[UserService] Attempting to inactivate user with ID: {id}");
            _UserStorage.Inactivate(id);
            _Logger.Info($"[UserService] Successfully inactivated user with ID: {id}");
        }
        catch (Exception ex)
        {
            _Logger.Error($"[UserService] Error inactivating user with ID: {id}", ex);
        }
    }



}