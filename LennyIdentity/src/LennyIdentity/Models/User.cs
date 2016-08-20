using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LennyIdentity.Models
{
    [Table("t_user")]
    public class User
    {
        [Column("id")]
        public int Id { set; get; }

        [Column("username")]
        [MaxLength(20)]
        public string UserName { set; get; }

        [Column("password")]
        [MaxLength(50)]
        public string Password { set; get; }
    }
}
