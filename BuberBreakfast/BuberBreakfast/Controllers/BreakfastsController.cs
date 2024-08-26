using Microsoft.AspNetCore.Mvc;
using CreateBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using BuberBreakfast.Services.Errors;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController{


    private readonly IBreakfastService _breakfastService;
    public BreakfastsController(IBreakfastService breakfastService){
        _breakfastService=breakfastService;
    }


    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request){


        var requestToCreateBreakfast = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet
        );
        if(requestToCreateBreakfast.IsError){
            return Problem(requestToCreateBreakfast.Errors);
        }
        var breakfast=requestToCreateBreakfast.Value;

        ErrorOr<Created> createBreakfastResult=_breakfastService.CreateBreakfast(breakfast);

        if (createBreakfastResult.IsError){
            return Problem(createBreakfastResult.Errors);
        }

        //respuesta 201 created y muestra response
        return createBreakfastResult.Match(
            created =>                 
                CreatedAtAction(
                    actionName: nameof(GetBreakfast),
                    routeValues:new {id=breakfast.Id},
                    value: MapBreakfastResponse(breakfast)
                ),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id){
        ErrorOr<Breakfast> getBreakfastResult=_breakfastService.GetBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors)
        );
    }


    // public IActionResult GetBreakfast(Guid id){
    //     ErrorOr<Breakfast> getBreakfastResult=_breakfastService.GetBreakfast(id);

    //     if(getBreakfastResult.IsError &&
    //        getBreakfastResult.FirstError == Errors.Breakfast.NotFound){

    //         return NotFound();
    //     }
    //     var breakfast= getBreakfastResult.Value;

    //     var response= new BreakfastResponse(

    //         breakfast.Id,
    //         breakfast.Name,
    //         breakfast.Description,
    //         breakfast.StartDateTime,
    //         breakfast.EndDateTime,
    //         breakfast.LastModifiedDateTime,
    //         breakfast.Savory,
    //         breakfast.Sweet

    //     );
    //     return Ok(response);
    // }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, CreateBreakfastRequest request){

        var requestToCreateBreakfast = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id
        );
        if(requestToCreateBreakfast.IsError){
            return Problem(requestToCreateBreakfast.Errors);
        }
        var breakfast=requestToCreateBreakfast.Value;
        ErrorOr <UpsertedBreakfast> upsertedResult=_breakfastService.UpsertBreakfast(breakfast); 
        //return 201 if created TODO
        return upsertedResult.Match(
            upserted => upserted.IsNewlyCreated ? 
                CreatedAtAction(
                    actionName: nameof(GetBreakfast),
                    routeValues:new {id=breakfast.Id},
                    value: MapBreakfastResponse(breakfast)
                ) 
            :NoContent(),
            errors => Problem(errors)
        );
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id){
       ErrorOr<Deleted> deletedResult= _breakfastService.DeleteBreakfast(id);

        return deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }


    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast){

        return new BreakfastResponse(

            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet

        );
    }
}