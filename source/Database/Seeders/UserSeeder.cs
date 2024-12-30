using Microsoft.Extensions.Configuration;
using TMS.Domain;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database.Seeders;

public class UserSeeder : ISeeder
{
    public async Task SeedAsync(Context context, IConfiguration configuration)
    {
        var userSet = context.Set<User>();

        var user = new User("Admin", "Admin", "admin","0507964387", "administrator@administrator.com", UserRole.Admin);


        if (userSet.Any(x => x.Email == user.Email))
        {
            var existingUser = await userSet.FirstOrDefaultAsync(x => x.Email == user.Email);

            existingUser.UpdateName(user.NameAr, user.NameEn);
            existingUser.UpdateRole(user.Role);

            userSet.Update(existingUser);
        }
        else
        {
            await userSet.AddAsync(user);
        }

        context.SaveChanges();


        var authSet = context.Set<Auth>();

        var auth = new Auth("admin",
            "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK+u88gtSXAyPDkW+hVS+dW4AmxrnaNFZks0Zzcd5xlb12wcF/q96cc4htHFzvOH9jtN98N5EBIXSvdUVnFc9kBuRTVytATZA7gITbs//hkxvNQ3eody5U9hjdH6D+AP0vVt5unZlTZ+gInn8Ze7AC5o6mn0Y3ylGO1CBJSHU9c/BcFY9oknn+XYk9ySCoDGctMqDbvOBcvSTBkKcrCzev2KnX7xYmC3yNz1Q5oPVKgnq4mc1iuldMlCxse/IDGMJB2FRdTCLV5KNS4IZ1GB+dw3tMvcEEtmXmgT2zKN5+kUkOxhlv5g1ZLgXzWjVJeKb5uZpsn3WK5kt8T+kzMoxHd5i8HxsU2uvy9GopxAnaV0WNsBPqTGkRllSxARl4ZN3hJqUla553RT49tJxbs+N03OmkYhjq+L0aKJ1AC+7G+rdjegiAQZB+3mdE7a2Pne2kYtpMoCmNMKdm9jOOVpfXJqZMQul9ltJSlAY6LPrHFUB3mw61JBNzx+sZgYN29GfDY=",
            user, new Guid("79005744-e69a-4b09-996b-08fe0b70cbb9"));

        if (authSet.Any(x => x.Login == auth.Login))
        {
            var existingAuth = await authSet.FirstOrDefaultAsync(x => x.Login == auth.Login);
            existingAuth.UpdatePassword(auth.Password);

            authSet.Update(existingAuth);
        }
        else
            await authSet.AddAsync(auth);


        await context.SaveChangesAsync();
    }
}
