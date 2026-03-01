namespace Biblioteca.Entities;

public class User(string id, string name, string email, DateTime created_at, Boolean IsActive)
{
    public string Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public DateTime Created_at { get; private set; } = created_at;
    public Boolean IsActive { get; private set; } = IsActive;

    public void Update(string email)
    {
        Email = email;
    }
    public void Inactivate()
    {
        IsActive = false;
    }
}

public class UpdateUserRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

