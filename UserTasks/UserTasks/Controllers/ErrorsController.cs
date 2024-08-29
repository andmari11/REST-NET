using Microsoft.AspNetCore.Mvc;

namespace UserTasks.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}