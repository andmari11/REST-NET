using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Contracts.User;
using UserTasks.Services.Tasks;
using CreateUsers.Contracts.User;

namespace UserTasks.Controllers;

public class UsersController : ApiController{

    private readonly IUserService _userService;
    public UsersController (IUserService userService){
        _userService=userService;
    }
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request){
        var requestCreateUser= Models.User.From(request);

        if(requestCreateUser.IsError){
            return Problem(requestCreateUser.Errors);
        }

        var user=requestCreateUser.Value;
        ErrorOr<Created>createUserResult=_userService.CreateUser(user);   

        return createUserResult.Match(
            onError: errors => Problem(createUserResult.Errors),
            onValue: created => CreatedAtAction(
                actionName: nameof(CreateUser),
                routeValues: new { id = user.Id },
                value: MapUserResponse(user)
            )
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id){
        var getUserResult=_userService.GetUser(id);

        return getUserResult.Match(
            onError: errors => Problem(getUserResult.Errors),
            onValue: user => Ok(MapUserResponse(user))
        );
    }

    private UserResponse MapUserResponse (Models.User user){
        return new UserResponse(
            user.Id,
            user.Nombre, 
            user.Email,
            user.FechaRegistro
        );
    }
}