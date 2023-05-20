using ETicaretApi.Context;
using ETicaretApi.Entities;
using ETicaretApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
// Add services to the container.

builder.Services.AddDbContext<ETicaretDbContext>();

//builder.Services.AddControllers();

builder.Services.AddControllers().AddFluentValidation(x =>
{

    x.ImplicitlyValidateChildProperties = true;
    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
