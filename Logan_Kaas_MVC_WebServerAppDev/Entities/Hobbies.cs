using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// LOGAN KAAS - WEEK 4 ASSIGNMENT
namespace Logan_Kaas_MVC_WebServerAppDev.Entities
{
    [Table("Hobbies")]
    public class Hobbies
    {
        public int HobbyId { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Favorite Hobby")]
        public string? FavoriteHobby { get; set; }
    }
}
