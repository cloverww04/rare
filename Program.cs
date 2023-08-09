using rare.Models;


// update subscription 

var builder = WebApplication.CreateBuilder(args);


List<Subscriptions> subscriptions = new List<Subscriptions>
{
    new Subscriptions()
    {
        Id = 1,
        FollowerId = 1,
        AuthorId = 1,
        CreatedOn = DateTime.Now,
    },

    new Subscriptions()
    {
        Id = 2,
        FollowerId = 2,
        AuthorId = 2,
        CreatedOn = DateTime.Today.AddMonths(-6)
    },

    new Subscriptions()
    {
        Id = 3,
        FollowerId = 3,
        AuthorId = 3,
        CreatedOn = DateTime.Today.AddMonths(-3)
    },

    new Subscriptions()
    {
        Id = 4,
        FollowerId = 4,
        AuthorId = 4,
        CreatedOn= DateTime.Today.AddYears(-2)
    }
};


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

List<Posts> posts = new List<Posts> 
{
    new Posts()
    {
        Id = 1,
        UserId = 1,
        CategoryId = 1,
        title = "New haircut",
        PublicationDate = DateTime.Now,
        Content = "Got a new haircut today. Looking fresh and clean",
        Approved = true,
    },

    new Posts() 
    {
        Id = 2,
        UserId = 2,
        CategoryId = 2,
        title = "Sexiest accent",
        PublicationDate = DateTime.Now,
        Content = "Naughty naughty. You tease me.",
        Approved = false
    },

    new Posts() 
    {
        Id = 3,
        UserId = 3,
        CategoryId = 3,
        title = "What Cheez-It falvor is the best?",
        PublicationDate = DateTime.Now,
        Content = "Hot & Spicy is the best because my name is Kyle, and I am never wrong.",
        Approved = true
    },

    new Posts() 
    {
        Id = 4,
        UserId = 4,
        CategoryId = 4,
        title = "Coffee",
        PublicationDate = DateTime.Now,
        Content = "Do you like your coffee black, or with cream and sugar?",
        Approved = true
    }
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// api calls for Post
app.MapGet("/posts", () => 
{
    return posts;
});

app.MapPut("/posts/{id}", (int id, Posts post) => 
{
    Posts postToUpdate = posts.FirstOrDefault(post => post.Id == id);
    int postIndex = posts.IndexOf(postToUpdate);
    if ( postToUpdate == null) 
    {
        return Results.NotFound();
    }

    if( id != post.Id ) 
    {
        return Results.BadRequest();
    }

    posts[postIndex] = post;
    return Results.Ok();
});

app.MapDelete("/posts/{id}", (int id) => 
{
    Posts postToDelete = posts.FirstOrDefault(pt => pt.Id == id);
    if (postToDelete == null) 
    {
        return Results.NotFound();
    }

    posts.Remove(postToDelete);
    return Results.Ok();

});

app.MapPost("/posts", (Posts post) => 
{
    post.Id = posts.Max(pt => pt.Id) + 1;
    posts.Add(post);
    return post;
});


// SUBSCRIPTIONS ENDPOINTS

app.MapPost("/subscriptions", (Subscriptions subscription) =>
{
    subscription.Id = subscriptions.Max(subs => subs.Id) + 1;
    subscriptions.Add(subscription);
    return subscription;
});


app.MapGet("/subscriptions", () =>
{
    return subscriptions;
});


app.MapDelete("/subscriptions/{id}", (int id) =>
{
    Subscriptions subscription = subscriptions.FirstOrDefault(subs => subs.Id == id);
    subscriptions.Remove(subscription);
    return subscription;
});


app.UseHttpsRedirection();

app.Run();
