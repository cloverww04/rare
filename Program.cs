using rare.Models;
using System.ComponentModel;

List<Comments> comments = new List<Comments>
{
    new Comments()
    {
        Id = 1,
        AuthorId = 1,
        PostId = 2,
        Content = "This is disgusting! Please tell me more!"
    },
    new Comments()
    {
        Id = 2,
        AuthorId = 3,
        PostId = 1,
        Content = "I don't know why you gagging, so!? She gives it to you every ball!!"
    },
    new Comments()
    {
        Id = 3,
        AuthorId = 2,
        PostId = 1,
        Content = "Have you try the honey rae's flavor?"
    },
    new Comments()
    {
        Id = 4,
        AuthorId = 4,
        PostId = 3,
        Content = "I STAN!!!!"
    },
    new Comments()
    {
        Id= 5,
        AuthorId = 3,
        PostId = 4,
        Content = "GYATTTT"
    }
};

List<Categories> categories = new List<Categories>
{
    new Categories()
    {
        Id = 1,
        Label = "Food"
    },
    new Categories()
    {
        Id = 2,
        Label = "Music"
    },
    new Categories()
    {
        Id = 3,
        Label = "Love"
    },
    new Categories()
    {
        Id = 4,
        Label = "Funny"
    },
    new Categories()
    {
        Id = 5,
        Label = "Dance"
    },
    new Categories()
    {
        Id = 6,
        Label = "TV"
    }
};

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/catergories", () =>
{
    return categories;
});

app.MapPost("/comments", (Comments comment) =>
{
    comment.Id = comments.Max(c => c.Id) + 1;
    comments.Add(comment);
    return comment;
});

app.MapPost("/categories", (Categories category) =>
{
    category.Id = categories.Max(c => c.Id) + 1;
    categories.Add(category);
    return category;
});

app.MapPut("/categories/{id}", (int id, Categories category) =>
{
    Categories categoryToUpdate = categories.FirstOrDefault(c => c.Id == id);
    int categoryIndex = categories.IndexOf(categoryToUpdate);
    if (categoryToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != category.Id) 
    {
        return Results.BadRequest();
    }
    categories[categoryIndex] = category;
    return Results.Ok();
});

app.MapPut("/comments/{id}", (int id, Comments comment) =>
{
    Comments commentToUpdate = comments.FirstOrDefault(c => c.Id == id);
    int commentIndex = comments.IndexOf(commentToUpdate);
    if (commentToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != comment.Id)
    {
        return Results.BadRequest();
    }
    comments[commentIndex] = comment;
    return Results.Ok();
});

app.MapDelete("/comments/{id}", (int id) =>
{
    Comments comment = comments.FirstOrDefault(c => c.Id == id);
    if (comment == null)
    {
        return Results.NotFound();
    }
    comments.Remove(comment);
    return Results.Ok(comment);
});

app.MapDelete("/categories/{id}", (int id) =>
{
    Categories category = categories.FirstOrDefault(c => c.Id == id);
    if (category == null)
    {
        return Results.NotFound();
    }
    categories.Remove(category);
    return Results.Ok(category);
});

app.Run();

