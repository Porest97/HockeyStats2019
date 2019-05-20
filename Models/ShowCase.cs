using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyStats2019.Models
{
    public class ShowCase
    {
        public int Id { get; set; }


        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }



        [Display(Name = "Showcase")]
        public string ShowCaseName { get; set; }
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }


        //Agegroupe
        [Display(Name = "Åldersgrupp")]
        public int? SeriesId { get; set; }
        [ForeignKey("SeriesId")]
        public Series AgeCategory { get; set; }

        //Location
        [Display(Name = "Plats")]
        public int? ArenaId1 { get; set; }
        [ForeignKey("ArenaId1")]
        public Arena Location { get; set; }











        //Coaching Staff
        [Display(Name = "Tränare")]
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Coach { get; set; }

        [Display(Name = "Tränare")]
        public int? PersonId1 { get; set; }
        [ForeignKey("PersonId1")]
        public Person Coach1 { get; set; }

        [Display(Name = "Tränare")]
        public int? PersonId2 { get; set; }
        [ForeignKey("PersonId2")]
        public Person Coach2 { get; set; }

        [Display(Name = "Tränare")]
        public int? PersonId3 { get; set; }
        [ForeignKey("PersonId3")]
        public Person Coach3 { get; set; }

        [Display(Name = "Domare")]
        public int? PersonId4 { get; set; }
        [ForeignKey("PersonId4")]
        public Person Referee { get; set; }




        //Administration Staff
        [Display(Name = "Showcase ansvarig")]
        public int? PersonId5 { get; set; }
        [ForeignKey("PersonId5")]
        public Person GeneralManager { get; set; }



    }
}
