using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Contracts.User;
using UserTasks.Models;


namespace UserTasks.Controllers;

public class UsersController : ApiController{

    [HttpPost]
    public IActionResult CreateUser(CretateUserRequest request){
        var requestCreateUser= User.Create();
        
        return Ok(new { Message = "User created successfully" });
    }
}