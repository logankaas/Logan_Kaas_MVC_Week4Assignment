using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// LOGAN KAAS - WEEK 4 ASSIGNMENT
namespace Logan_Kaas_MVC_WebServerAppDev.Entities
{
    [Table("FavoriteBreakfast")]
    public class FavoriteBreakfast
    {
        public int FavoriteBreakfastId { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Favorite Breakfast Food")]
        public string? FavoriteBreakfastFood { get; set; }
    }
}
