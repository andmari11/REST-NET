using Microsoft.AspNetCore.SignalR;
using ErrorOr;
using BuberBreakfast.Services.Errors;

namespace BuberBreakfast.Models;

public class Breakfast{
    public const int MinNameLength=3;
    public const int MaxNameLength=50;


    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }


    private Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet){
        
        //comprobar lógica
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime= lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }
    //enforce
    public static ErrorOr<Breakfast> Create(string name, string description, DateTime startDateTime, DateTime endDateTime, List<string> savory, List<string> sweet, Guid? id=null){
        List<Error> errors=new();
        
        if(name.Length<MinNameLength || name.Length>MaxNameLength){
            
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (errors.Count>0){

            return errors;
        }

        return new Breakfast(id ?? Guid.NewGuid(),name, description, startDateTime, endDateTime, DateTime.UtcNow, savory, sweet );
    }

}