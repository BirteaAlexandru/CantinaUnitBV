using Domain.Base;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User : Entity
{
    public Email Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }
    public long RoleId { get; private set; }
    public Role Role { get; private set; }
    public ICollection<Order> Orders { get; private set; }

    private User()
    {
    }

    private User(Email email, string password, string firstName, string secondName, long roleId)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        SecondName = secondName;
        RoleId = roleId;
    }

    public static Result<User> Create(Email email, string password, string firstName, string secondName, long roleId)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<User>("First name cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(secondName))
        {
            return Result.Failure<User>("Second name cannot be empty");
        }

        if (roleId == 0)
        {
            return Result.Failure<User>("Role is mandatory");
        }

        var user  = new User(email, password, firstName, secondName, roleId);

        return Result.Success(user);
    }

    public Result<User> Update(string firstName, string secondName, long roleId)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<User>("First name cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(secondName))
        {
            return Result.Failure<User>("Second name cannot be empty");
        }

        FirstName = firstName;
        SecondName = secondName;

        return Result.Success(this);
    }
}