using System.ComponentModel.DataAnnotations;

namespace Petty.Models
{
    public class UsersModel
    {
        [Key]
        public int User_ID { get; set; }
        public string User_Name { get; set;}
        public string User_Email { get; set;}
        public string User_Password { get; set;}
        public string User_IsAdmin { get;set;}
    }
}
