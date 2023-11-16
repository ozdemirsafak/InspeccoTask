using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserRole:BaseEntity
    {
      
        
        public string? RoleName { get; set; }

        // İlişkiyi ifade eden property
        public virtual ICollection<User>? Users { get; set; }
    }
}
