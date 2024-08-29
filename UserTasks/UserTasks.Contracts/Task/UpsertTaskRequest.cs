namespace Contracts.Task;

public record UpsertTaskRequest(
    Guid Id,    
    string Nombre,
    string Titulo,
    string Descripcion,
    string Estado, 
    DateTime FechaRegistro,
    DateTime FechaActualizacion,
    Guid UserId
);