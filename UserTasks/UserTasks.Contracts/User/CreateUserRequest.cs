namespace Contracts.User;

public record CreateUserRequest(
    string Nombre,
    string Email
);