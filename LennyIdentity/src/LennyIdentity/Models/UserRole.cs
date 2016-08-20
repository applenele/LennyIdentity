using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LennyIdentity.Models
{
    [Table("userrole")]
    public class UserRole
    {
        [Column("id")]
        public int Id { set; get; }

        [Column("user_id")]
        public int UserId { set; get; }

        [Column("role_id")]
        public int RoleId { set; get; }
    }
}
