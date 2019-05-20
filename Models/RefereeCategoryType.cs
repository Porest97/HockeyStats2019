using System.ComponentModel.DataAnnotations;

namespace HockeyStats2019.Models
{
    public class RefereeCategoryType
    {
        public int Id { get; set; }

        [Display(Name = "DomarKategori Typ")]
        public string RefereeCategoryTypeName { get; set; }
    }
}