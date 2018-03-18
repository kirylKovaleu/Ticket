using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MvcInternetApplication.Models
{
    public class TheaterContext:DbContext
    {
        public TheaterContext() : base("TheaterConnection")
        {

        }
        public virtual DbSet<UserPaid> UserPaid { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
    }

}