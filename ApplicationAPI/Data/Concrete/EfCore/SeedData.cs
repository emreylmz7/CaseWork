using ApplicationAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAPI.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void FillTestData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<ApplicationContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName = "emreyilmaz", Image = "p1.jpg",Name = "Emre Yılmaz",Email = "emreyilmaz@gmail.com",Password = "123456"},
                        new User {UserName = "sadikturan", Image = "p2.jpg",Name = "Sadık Turan",Email = "sadikturan@gmail.com",Password = "123456"}
                    );
                    context.SaveChanges();
                };
                
                if (!context.JobPositions.Any())
                {
                    context.JobPositions.AddRange(
                        new JobPosition {
                            Title = "ASP.NET Core Developer Hiring",
                            Description = "We are hiring ASP.NET Core Developer",
                            Content = "...",
                            Url = "aspnet-core-hiring",
                            IsActive = true,
                            PostedDate = DateTime.Now.AddDays(-10),
                            Image = "1.jpg",
                        },
                        new JobPosition {
                            Title = "Angular Developer Hiring",
                            Description = "We are hiring Angular Developer",
                            Content = "...",
                            Url = "angular-dev-hiring",
                            IsActive = true,
                            PostedDate = DateTime.Now.AddDays(-15),
                            Image = "2.png",
                        },
                        new JobPosition {
                            Title = "React Developer Hiring",
                            Description = "We are hiring React Developer",
                            Content = "...",
                            Url = "react-dev-hiring",
                            IsActive = true,
                            PostedDate = DateTime.Now.AddDays(-20),
                            Image = "4.png",
                        }
                    );
                    context.SaveChanges();
                };
            }
        }
    }
}