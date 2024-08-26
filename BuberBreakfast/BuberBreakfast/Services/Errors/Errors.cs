using ErrorOr;

namespace BuberBreakfast.Services.Errors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast not found"
        );
    
        public static Error InvalidName => Error.Validation(
            code: "Breakfast.InvalidName",
            description: "Breakfast name must be {Models.Breakfast.MinNameLength}-{Models.Breakfast.MaxNameLength} characters long."
        );
    }
}