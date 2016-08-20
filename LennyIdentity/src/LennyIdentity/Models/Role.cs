using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LennyIdentity.Models
{
    [Table("t_role")]
    public class Role
    {
        [Column("id")]
        public int Id { set; get; }

        [Column("rolename")]
        public string RoleName { set; get; }
    }
}
