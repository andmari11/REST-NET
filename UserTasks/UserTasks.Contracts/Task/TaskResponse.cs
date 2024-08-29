namespace Contracts.Task;

public record TaskResponse(
    Guid Id,
    string Nombre,
    string Email,
    DateTime FechaRegistro
);