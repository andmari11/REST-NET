using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();


    //AddScoped: se registra con un tiempo de vida para la solicitud
    //Addtransient: nueva instancia cada solicitud
    //AddSingleton: una sola instancia
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}


var app = builder.Build();
{
    //app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


