using rare.Models;

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

List<Reactions> reactions = new()
{
    new Reactions()
    {
        Id = 1,
        emoji = "👍"
    },
    new Reactions()
    {
        Id = 2,
        emoji =  "👎"
    },
    new Reactions()
    {
        Id = 3,
        emoji = "👏"
    },
    new Reactions()
    {
        Id = 4,
        emoji = "💖"
    },
    new Reactions()
    {
        Id = 5,
        emoji = "\U0001f7e7"
    }
};


List<PostTags> PostTagList = new List<PostTags>
{
    new PostTags()
    {
        Id = 1,
        TagId = 1,
        PostId = 1
    },
    new PostTags()
    {
        Id = 2,
        TagId = 2,
        PostId = 2
    },
    new PostTags()
    {
        Id = 3,
        TagId =3,
        PostId = 3
    },
    new PostTags()
    {
        Id = 4,
        TagId = 4,
        PostId = 4
    },

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

// api calls for Post
app.MapGet("/posts", () =>
{
    return posts;
});

app.MapPut("/posts/{id}", (int id, Posts post) =>
{
    Posts postToUpdate = posts.FirstOrDefault(post => post.Id == id);
    int postIndex = posts.IndexOf(postToUpdate);
    if (postToUpdate == null)
    {
        return Results.NotFound();
    }

    if (id != post.Id)
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

// POST TAG ENDPOINTS

app.MapGet("posts/{id}/postTags", (int id) =>
{
    Posts post = posts.FirstOrDefault(p => p.Id == id);
    List<PostTags> assignedPostTags = PostTagList.Where(c => c.PostId.Equals(id)).ToList();
    return assignedPostTags;
});


app.MapPost("/postTags", (int postId, int tagId) =>
{
    PostTags postTag = new PostTags
    {
        Id = PostTagList.Max(postTag => postTag.Id) + 1,
        PostId = postId,
        TagId = tagId
    };
});


app.MapDelete("/posts/tags/{postTagId}", (int postTagId) =>
{
    PostTags postTag = PostTagList.FirstOrDefault(postTag => postTag.Id == postTagId);
    PostTagList.Remove(postTag);
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

app.MapPost("/subscriptions/{followerId}/{authorId}", (int followerId, int authorId) =>
{
    Users follower = users.FirstOrDefault(u => u.Id == followerId);
    Users author = users.FirstOrDefault(u => u.Id == authorId);

    if (follower == null || author == null)
    {
        return Results.NotFound();
    }

    if (subscriptions.Any(sub => sub.FollowerId == followerId && sub.AuthorId == authorId))
    {
        return Results.Conflict();
    }

    Subscriptions newSubscription = new Subscriptions
    {
        Id = subscriptions.Max(sub => sub.Id) + 1,
        FollowerId = followerId,
        AuthorId = authorId,
        CreatedOn = DateTime.Now
    };

    subscriptions.Add(newSubscription);
    return Results.Created($"/subscriptions/{newSubscription.Id}", newSubscription);
});


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

// Categories Endpoints

app.MapGet("/catergories", () =>
{
    return categories;
});


app.MapPost("/categories", (Categories category) =>
{
    category.Id = categories.Max(c => c.Id) + 1;
    categories.Add(category);
    return category;
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

// Comments Endpoints

app.MapPost("/comments", (Comments comment) =>
{
    comment.Id = comments.Max(c => c.Id) + 1;
    comments.Add(comment);
    return comment;
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


app.MapGet("/reactions", () =>
{
    return reactions;
});

app.MapGet("/reactions/{id}", (int id) =>
{
    Reactions reaction = reactions.FirstOrDefault(r => r.Id == id);

    if (reaction == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(reaction);
});

app.Run();
