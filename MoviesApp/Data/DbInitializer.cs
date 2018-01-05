using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Data
{
  public static class DbInitializer
  {
    public static void Initialize(MovieContext context)
    {
      context.Database.EnsureCreated();

      if (context.Movies.Any())
      {
        return;
      }

      var movies = new Movie[]
      {
          new Movie
          {
            Title = "Star Wars - The Last Jedi",
            Year = 2017,
            Director = "Rian Johnson",
            Description = "Rey develops her newly discovered abilities with the guidance of Luke Skywalker, who is unsettled by the strength of her powers. Meanwhile, the Resistance prepares for battle with the First Order."
          },
          new Movie
          {
            Title = "Blade Runner 2049",
            Year = 2017,
            Director = "Denis Villeneuve",
            Description = "A young blade runner's discovery of a long-buried secret leads him to track down former blade runner Rick Deckard, who's been missing for thirty years."
          },
          new Movie
          {
            Title = "Logan",
            Year = 2017,
            Director = "James Mangold",
            Description = "In the near future, a weary Logan cares for an ailing Professor X, somewhere on the Mexican border. However, Logan's attempts to hide from the world, and his legacy, are upended when a young mutant arrives, pursued by dark forces."
          },
          new Movie
          {
            Title = "Justice League",
            Year = 2017,
            Director = "Zack Snyder",
            Description = "Fueled by his restored faith in humanity and inspired by Superman's selfless act, Bruce Wayne enlists the help of his newfound ally, Diana Prince, to face an even greater enemy."
          },
          new Movie
          {
            Title = "Thor: Ragnarok",
            Year = 2017,
            Director = "Taika Waititi",
            Description = "Imprisoned, the mighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally. Thor must fight for survival and race against time to prevent the all-powerful Hela from destroying his home and the Asgardian civilization."
          }
      };

      foreach (var movie in movies)
      {
        context.Movies.Add(movie);
      }
      context.SaveChanges();
    }
  }
}
