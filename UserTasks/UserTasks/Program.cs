//using UserTasks.Services.Users;

using UserTasks.Services.Tasks;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();


    //AddScoped: se registra con un tiempo de vida para la solicitud
    //Addtransient: nueva instancia cada solicitud
    //AddSingleton: una sola instancia
    builder.Services.AddScoped<IUserService, UserService>();
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    //app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


