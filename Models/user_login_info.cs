using System.ComponentModel.DataAnnotations;

namespace cmcs_poe_part1.Models
{
    public class user_login_info
    {
       
            [Key]
            public string Email { get; set; }
            public string Password { get; set; }
        }

    }

