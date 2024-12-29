namespace AjKpi.Domain;

public class Auth : BaseAuditableEntity
{
    public Auth
    (
        string login,
        string password,
        User user
        //long? roleId
    )
    {
        Login = login;
        Password = password;
        User = user;
        Salt = Guid.NewGuid();
        //RoleId = roleId;
        // Roles = Roles.User;
    }

    public Auth(long id) => Id = id;

    public Auth()
    {
    }

    public Auth (string? login  , string? password , User? user , Guid? salt) => (Login , Password , User , Salt ) = (login , password , user , salt.Value );

    public string? Login { get; private set; }

    public string? Password { get; private set; }

    public Guid Salt { get; private set; }

    // public Role Role { get; private set; }
    // public long? RoleId { get; private set; }

    public User? User { get; private set; }

    public void UpdatePassword(string password) => Password = password;
}
