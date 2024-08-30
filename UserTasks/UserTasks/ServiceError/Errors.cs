using ErrorOr;
using UserTasks.Models;

namespace UserTasks.ServiceError.Errors;

public static class Errors
{
    public static class User{
        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found"
        );
        public static Error ExistingId => Error.Conflict(
            code: "User.ExistingId",
            description: "Id already exists, cant create"
        );
        public static Error InvalidName => Error.Validation(
            code: "User.InvalidName",
            description: "User name must be {Models.User.MinNameLength}-{Models.User.MaxNameLength} characters long."
        );
    }

}