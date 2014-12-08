using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace s00132397DanielShimizu.Models
{

    class FilmDbInitialiser : DropCreateDatabaseAlways<FilmDb>
    {
        protected override void Seed(FilmDb context)
        {
            var films = new List<Film>()
            {
                new Film() {Title = "22 Jump Street", ReleaseDate = DateTime.Parse("04/06/2014"),
                Genre = Genre.Comedy, Actors = new List<Actor>()
                {
                    new Actor()
                    { Name = "Channing Tatum",
                    Sex = Sex.Male
                    },
                    new Actor()
                    { Name = "Jonah Hill",
                        Sex = Sex.Male                    
                    }
                }},
                new Film(){Title = "Guardians of the Galaxy", ReleaseDate = DateTime.Parse("05/06/2014"),
                Genre = Genre.Action, Actors = new List<Actor>()
                {
                    new Actor()
                    { Name = "Chris Pratt",
                    Sex = Sex.Male
                    },
                    new Actor()
                    { Name = "Bradley Cooper",
                    Sex = Sex.Male
                    },
                    new Actor()
                    { Name = "Vin Diesel",
                    Sex = Sex.Male
                    },
                    new Actor()
                    { Name = "Zoe Saldana",
                    Sex = Sex.Female
                    },
                    new Actor()
                    { Name = "Dave Batista",
                    Sex = Sex.Male
                    }
                }},
                new Film(){Title = "Shawshank Redemption", ReleaseDate = DateTime.Parse("23/09/1994"), Genre = Genre.Drama, 
                    Actors = new List<Actor>()             
                {
                new Actor()
                    { Name = "Tim Robbins", Sex = Sex.Male},                    
                    new Actor()
                    { Name = "Morgan Freeman", Sex = Sex.Male},
                    new Actor()
                    { Name = "Bob Gunton",Sex = Sex.Male },
                    new Actor()
                   { Name = "Clancy Brown", Sex = Sex.Male }
                }},  
             new Film(){Title = "RED", ReleaseDate = DateTime.Parse("29/09/2010"), Genre = Genre.Action, 
                    Actors = new List<Actor>()             
                {
                new Actor()
                    { Name = "Morgan Freeman", Sex = Sex.Male},                    
                    new Actor()
                    { Name = "Bruce Willis", Sex = Sex.Male},
                    new Actor()
                    { Name = "John Malcovic",Sex = Sex.Male },
                    new Actor()
                   { Name = "Mary-Louise Parker", Sex = Sex.Female },
                   new Actor()
                   {Name = "Helen Mirren", Sex= Sex.Female}
                }},
                new Film(){Title = "Die Hard", ReleaseDate = DateTime.Parse("15/03/1988"), Genre = Genre.Action, 
                    Actors = new List<Actor>()             
                {
                new Actor()
                    { Name = "Bruce Willis", Sex = Sex.Male},                    
                    new Actor()
                    {Name = "Bonnie Bedelia",Sex = Sex.Male}                   
                }}  
                };
            films.ForEach(flm => context.Films.Add(flm));
            context.SaveChanges();

            base.Seed(context);
        }
    }

    class FilmDb : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public FilmDb()
            : base("FilmDbs")
        { }
    }
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        [Display(Name = "Film Name"), Required]
        public string Title { get; set; }

        [DisplayName("Released"), DataType(DataType.Date),
                DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }
        public virtual List<Actor> Actors { get; set; }

    }
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
    }
    public enum Sex
    {
        Male, Female
    }

    public enum Genre
    {
        Action, Horror, Comedy, Romance, Thriller, Drama
    }

}
