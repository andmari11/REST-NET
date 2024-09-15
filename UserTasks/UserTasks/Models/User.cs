using ErrorOr;
using Contracts.User;
using UserTasks.ServiceError.Errors;

namespace UserTasks.Models;
public class User{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 20;
    public Guid Id { get; }
    public string Nombre { get; }
    public string Email { get; }
    public DateTime FechaRegistro { get; }

    private User(Guid id, string nombre, string email, DateTime fechaRegistro)
    {
        Id = id;  
        Nombre = nombre;
        Email = email;
        FechaRegistro = fechaRegistro;
    }

    public static ErrorOr<User> Create(string nombre, string email, DateTime fechaRegistro, Guid? id=null){
        List<Error> errors=new();
        if(nombre.Length < MinNameLength || nombre.Length > MaxNameLength){
            errors.Add(Errors.User.InvalidName);
        }
        if (errors.Count>0)
            return errors;

        return new User (id ?? Guid.NewGuid(),nombre, email, fechaRegistro);        
    }

    public static ErrorOr<User> From(CreateUserRequest request){

        return Create(
            request.Nombre, 
            request.Email,
            DateTime.Now
        );
    }
    public static ErrorOr<User> From(Guid id, UpsertUserRequest request){

        return Create(
            request.Nombre, 
            request.Email,
            DateTime.Now,
            id
        );
    }
}
