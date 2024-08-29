namespace Contracts.User;

public record UpsertUserRequest(
    string Nombre,
    string Email
);