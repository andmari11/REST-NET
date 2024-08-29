namespace CreateUsers.Contracts.User;

public record UserResponse(
    Guid Id,
    string Nombre,
    string Email,
    DateTime FechaRegistro
);