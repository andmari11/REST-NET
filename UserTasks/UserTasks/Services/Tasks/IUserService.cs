using UserTasks.Models;
using ErrorOr;

namespace UserTasks.Services.Tasks;

public interface IUserService {
    ErrorOr<Created> CreateUser (User user);
    ErrorOr<UpsertUserResult> UpsertUser (User user);
    ErrorOr<User> GetUser(Guid id);
    ErrorOr<Deleted> DeleteUser(Guid id);
}