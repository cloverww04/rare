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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
