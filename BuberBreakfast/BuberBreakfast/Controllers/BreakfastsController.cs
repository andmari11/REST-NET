using Microsoft.AspNetCore.Mvc;
using CreateBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;

namespace BuberBreakfast.Controllers;

[ApiController]
//[Route ("breakfasts")] es igual a clase sin Controller 
[Route("[controller]")]
public class BreakfastsController : ControllerBase{


    private readonly IBreakfastService _breakfastService;
    public BreakfastsController(IBreakfastService breakfastService){
        _breakfastService=breakfastService;
    }




    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request){

        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        //TODO save to database
        _breakfastService.CreateBreakfast(breakfast);

        var response= new BreakfastResponse(

            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet

        );

        //respuesta 201 created y muestra response
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues:new {id=breakfast.Id},
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id){
        Breakfast breakfast=_breakfastService.GetBreakfast(id);


        var response= new BreakfastResponse(

            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet

        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, CreateBreakfastRequest request){

        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        _breakfastService.UpsertBreakfast(breakfast);
        //return 201 if created TODO
        return NoContent();
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id){
        _breakfastService.DeleteBreakfast(id);

        return NoContent();
    }
}