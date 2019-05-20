using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HockeyStats2019.Models;

namespace HockeyStats2019.Models
{
    public class HockeyStats2019Context : DbContext
    {
        public HockeyStats2019Context (DbContextOptions<HockeyStats2019Context> options)
            : base(options)
        {
        }

        public DbSet<HockeyStats2019.Models.Arena> Arena { get; set; }

        public DbSet<HockeyStats2019.Models.Person> Person { get; set; }

        public DbSet<HockeyStats2019.Models.RefereeCategory> RefereeCategory { get; set; }

        public DbSet<HockeyStats2019.Models.RefereeCategoryType> RefereeCategoryType { get; set; }

        public DbSet<HockeyStats2019.Models.RefereeDistrict> RefereeDistrict { get; set; }

        public DbSet<HockeyStats2019.Models.RefereeType> RefereeType { get; set; }

        public DbSet<HockeyStats2019.Models.Series> Series { get; set; }
                
        public DbSet<HockeyStats2019.Models.Team> Team { get; set; }
                
        public DbSet<HockeyStats2019.Models.Game> Game { get; set; }
                
        public DbSet<HockeyStats2019.Models.ShowCase> ShowCase { get; set; }
    }
}
