using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User:BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
		[StringLength(150)]
		public string Username { get; set; }
		[StringLength(20)]
		public string Password { get; set; }

        [ForeignKey(nameof(User.UserRoleId))]
        // İlişkiyi ifade eden property
        public virtual UserRole? UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
