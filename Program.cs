using rare.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

List<Users> users = new List<Users>
{
    new Users()
    {
        Id = 1,
        FirstName = "Nathan",
        LastName = "Clover",
        Email = "nathan@code.com",
        Password = "123",
        Bio = "Nathan's BIO",
        Username = "NathanC",
        CreatedOn = new DateTime(2023,08,07),
        Active = true
    },
    new Users()
    {
        Id = 2,
        FirstName = "Dimitric",
        LastName = "Brown",
        Email = "dimitric@react.com",
        Password = "456",
        Bio = "Dimitric's BIO",
        Username = "Beyonce B",
        CreatedOn = new DateTime(2023,07,07),
        Active = true
    },
    new Users()
    {
        Id = 3,
        FirstName = "Kyle",
        LastName = "Blunt",
        Email = "kyle@javascript.com",
        Password = "789",
        Bio = "Kyle's BIO",
        Username = "spicycheezit",
        CreatedOn = new DateTime(2023,06,07),
        Active = true
    },
    new Users()
    {
        Id = 4,
        FirstName = "Cameron",
        LastName = "Dorris",
        Email = "cameron@csharp.com",
        Password = "1011",
        Bio = "Cameron's BIO",
        Username = "CameronD",
        CreatedOn = new DateTime(2023,08,08),
        Active = true
    }
};


// Add services to the container.
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

app.UseHttpsRedirection();

// Users Endpoints:

app.MapGet("/users/username", () =>
{
    return users.OrderBy(user => user.Username);
});

app.MapGet("/users", () =>
{
    return users;
});

app.MapGet("/users/{id}", (int id) =>
{
    Users user = users.FirstOrDefault(user => user.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.MapDelete("/users/{id}", (int id) =>
{
    Users user = users.FirstOrDefault(user => user.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }
    users.Remove(user);
    return Results.Ok(users);
});

app.MapGet("/users/active", () =>
{
    List<Users> active = users.Where(user => user.Active == true).ToList();
    return active;
});

app.MapPost("/users", (Users user) =>
{
    user.Id = users.Max(user => user.Id) + 1;
    user.CreatedOn = DateTime.Now;
    users.Add(user);
    return users;
});

app.MapPut("/users/{id}", (int id, Users user) =>
{
    Users userToUpdate = users.FirstOrDefault(user => user.Id == id);
    int userIndex = users.IndexOf(userToUpdate);

    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != user.Id)
    {
        return Results.BadRequest();
    }
    users[userIndex] = user;
    return Results.Ok(users);  
});

app.Run();

