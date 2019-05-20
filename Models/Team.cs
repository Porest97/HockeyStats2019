using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyStats2019.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Lag namn")]
        public string TeamName { get; set; }


        [Display(Name = "Huvudtränare")]
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person HeadCoach { get; set; }

        [Display(Name = "Ass.Tränare")]
        public int? PersonId1 { get; set; }
        [ForeignKey("PersonId1")]
        public Person AssCoach { get; set; }

        [Display(Name = "Ass.Tränare")]
        public int? PersonId2 { get; set; }
        [ForeignKey("PersonId2")]
        public Person AssCoach1 { get; set; }
    }
    
       
}
