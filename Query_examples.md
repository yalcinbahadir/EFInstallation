# EFInstallation
//Eagerly Loading
//Include is an extension method in the System.Data.Entity namespace so make sure you are using that namespace.

using (var context = new BloggingContext())
{
    // Load all blogs and related posts.
    var blogs1 = context.Blogs
                        .Include(b => b.Posts)
                        .ToList();

    // Load one blog and its related posts.
    var blog1 = context.Blogs
                       .Where(b => b.Name == "ADO.NET Blog")
                       .Include(b => b.Posts)
                       .FirstOrDefault();

    // Load all blogs and related posts
    // using a string to specify the relationship.
    var blogs2 = context.Blogs
                        .Include("Posts")
                        .ToList();

    // Load one blog and its related posts
    // using a string to specify the relationship.
    var blog2 = context.Blogs
                       .Where(b => b.Name == "ADO.NET Blog")
                       .Include("Posts")
                       .FirstOrDefault();
}

//Eagerly loading multiple levels
using (var context = new BloggingContext())
{
    // Load all blogs, all related posts, and all related comments.
    var blogs1 = context.Blogs
                        .Include(b => b.Posts.Select(p => p.Comments))
                        .ToList();

    // Load all users, their related profiles, and related avatar.
    var users1 = context.Users
                        .Include(u => u.Profile.Avatar)
                        .ToList();

    // Load all blogs, all related posts, and all related comments  
    // using a string to specify the relationships.
    var blogs2 = context.Blogs
                        .Include("Posts.Comments")
                        .ToList();

    // Load all users, their related profiles, and related avatar  
    // using a string to specify the relationships.
    var users2 = context.Users
                        .Include("Profile.Avatar")
                        .ToList();
}

source:https://docs.microsoft.com/en-us/ef/ef6/querying/related-data
