namespace StreamPowered.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Newtonsoft.Json;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using System.Collections.Generic;
    using DTOs;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StreamPowered.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }

            if (!context.Genres.Any())
            {
                this.SeedGenres(context);
            }

            if (!context.Games.Any())
            {
                this.SeedGames(context);
            }

            if (!context.Ratings.Any())
            {
                this.SeedRatings(context);
            }

            if (!context.Reviews.Any())
            {
                this.SeedReviews(context);
            }
        }

        private void SeedReviews(ApplicationDbContext context)
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath("~/Resources/reviews.json"));
            var reviewDtos = JsonConvert.DeserializeObject<ICollection<ReviewDTO>>(json);
            foreach (var reviewDto in reviewDtos)
            {
                var review = new Review
                {
                    Content = reviewDto.Content,
                    CreationTime = DateTime.Parse(reviewDto.CreationTime),
                    Author = context.Users.FirstOrDefault(r => r.UserName.Equals(reviewDto.Author)),
                    Game = context.Games.FirstOrDefault(r => r.Title.Equals(reviewDto.Game))
                };
                context.Reviews.Add(review);
            }
            context.SaveChanges();
        }

        private void SeedRatings(ApplicationDbContext context)
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath("~/Resources/ratings.json"));
            var ratingDtos = JsonConvert.DeserializeObject<ICollection<RatingDTO>>(json);
            foreach (var ratingDto in ratingDtos)
            {
                var rating = new Rating
                {
                    RatingValue = ratingDto.Value,
                    Author = context.Users.FirstOrDefault(r => r.UserName.Equals(ratingDto.Author)),
                    Game = context.Games.FirstOrDefault(r => r.Title.Equals(ratingDto.Game))
                };
                context.Ratings.Add(rating);
            }
            context.SaveChanges();
        }

        private void SeedGames(ApplicationDbContext context)
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath("~/Resources/games.json"));
            var gameDtos = JsonConvert.DeserializeObject<ICollection<GameDTO>>(json);
            foreach (var gameDto in gameDtos)
            {
                var game = new Game
                {
                    Title = gameDto.Title,
                    Description = gameDto.Description,
                    Genre = context.Genres.FirstOrDefault(g => g.Name.Equals(gameDto.Genre)),
                    SystemRequirements = gameDto.SystemRequirements
                };
                foreach (var imageUrl in gameDto.ImageUrls)
                {
                    game.ImageUrls.Add(new ImageUrl { Url = imageUrl });
                }
                context.Games.Add(game);
            }
            context.SaveChanges();
        }

        private void SeedGenres(ApplicationDbContext context)
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath("~/Resources/genres.json"));
            var genres = JsonConvert.DeserializeObject<ICollection<Genre>>(json);
            foreach (var genre in genres)
            {
                context.Genres.Add(genre);
            }
            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            // Add "Administrator" role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole("Admin"));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join(";", roleCreateResult.Errors));
            }

            var json = File.ReadAllText(HostingEnvironment.MapPath("~/Resources/users.json"));
            var userDtos = JsonConvert.DeserializeObject<ICollection<UserDTO>>(json);

            foreach (var userDto in userDtos)
            {
                var user = this.CreateUser(userManager, userDto.UserName, userDto.Email, userDto.Password);

                if (userDto.Role == "Admin")
                {
                    var addRoleResult = userManager.AddToRole(user.Id, "Admin");
                    if (!addRoleResult.Succeeded)
                    {
                        throw new Exception(string.Join("; ", addRoleResult.Errors));
                    }
                }
            }

            context.SaveChanges();
            
        }

        private ApplicationUser CreateUser(UserManager<ApplicationUser> userManager, string username, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join(";", userCreateResult.Errors));
            }

            return user;
        }
    }
}
