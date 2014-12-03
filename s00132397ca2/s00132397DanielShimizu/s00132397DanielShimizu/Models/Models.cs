using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace s00132397DanielShimizu.Models
{

     class CampDbInitialiser : DropCreateDatabaseAlways<FilmDb>
    {
        protected override void Seed(FilmDb context)
        {

        }
    }
    class FilmDb:DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        

        public FilmDb()
            :base("FilmDb")
        {
        }
        public class Film
        {
            [Key]
            public int FimlId { get; set; }
            [Display(Name = "Camp Name"), Required]
            public string Title { get; set; }
            public virtual List<Actor> Actors { get; set; }
            public DateTime ReleaseDate { get; set; }
            public Genre Genre { get; set; }
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
            Action, Horror, Comedy, Romance, Thriller
        }

    }
}