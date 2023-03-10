using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servieScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servieScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name ="Cimema 1",
                            Logo ="http://dotnethow.net/images/cinemas/cinema-1",
                            Descritpion= "This is the descritpion of the first cinema"

                        },
                         new Cinema()
                        {
                            Name ="Cimema 2",
                            Logo ="http://dotnethow.net/images/cinemas/cinema-2",
                            Descritpion= "This is the descritpion of the first cinema"

                        },
                          new Cinema()
                        {
                            Name ="Cimema 3",
                            Logo ="http://dotnethow.net/images/cinemas/cinema-3",
                            Descritpion= "This is the descritpion of the first cinema"

                        },
                         new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Descritpion = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Descritpion = "This is the description of the first cinema"
                        },

                    });
                    context.SaveChanges();

                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor() {
                            FullName = "Actro 1",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-1"
                        },
                         new Actor() {
                            FullName = "Actro 2",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-2"
                        },
                          new Actor() {
                            FullName = "Actro 3",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-3"
                        },
                           new Actor() {
                            FullName = "Actro 4",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-4"
                        },
                           new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer() {
                            FullName = "Producer 1",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-1"
                        },
                         new Producer() {
                            FullName = "Producer 2",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-2"
                        },
                          new Producer() {
                            FullName = "Producer 3",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-3"
                        },
                           new Producer() {
                            FullName = "Actro 4",
                            Bio ="This the Bio of the first Actor",
                            ProfilePictureURL="http://dotnethow.net/images/producers/producer-4"
                        },
                            new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();


                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();



                }
                //Actros &Movies

                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();

                }

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
