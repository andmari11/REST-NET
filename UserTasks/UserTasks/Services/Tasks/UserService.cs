using UserTasks.Models;
using UserTasks.ServiceError.Errors;
using ErrorOr;

namespace UserTasks.Services.Tasks;

public class UserService : IUserService
{
    private static readonly Dictionary <Guid, User> _users =new();

    ErrorOr<Created> IUserService.CreateUser(User user)
    {
        if(_users.TryAdd(user.Id, user)){
            return Result.Created;
        }
        return Errors.User.ExistingId;
    }

    ErrorOr<Deleted> IUserService.DeleteUser(Guid id)
    {
        if (_users.Remove(id))
        {
            return Result.Deleted;
        }
        return Errors.User.NotFound;
    }


    ErrorOr<User> IUserService.GetUser(Guid id)
    {
        if(_users.ContainsKey(id)){
            return _users[id];
        }
        return Errors.User.NotFound;
    }

    ErrorOr<UpsertUserResult> IUserService.UpsertUser(User user)
    {
        throw new NotImplementedException();
    }
}
