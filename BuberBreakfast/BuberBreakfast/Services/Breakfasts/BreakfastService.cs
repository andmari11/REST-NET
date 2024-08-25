namespace BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Errors;
using ErrorOr;


//administra la bbdd
public class BreakfastService: IBreakfastService{

    private static readonly Dictionary <Guid, Breakfast> _breakfasts=new();

    public void CreateBreakfast(Breakfast breakfast){

        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id){
        if(_breakfasts.TryGetValue(id, out var breakfast)){

            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }

    public void UpsertBreakfast(Breakfast breakfast){

        _breakfasts[breakfast.Id]=breakfast;
    }
    public void DeleteBreakfast(Guid id){
        _breakfasts.Remove(id);
    }

}