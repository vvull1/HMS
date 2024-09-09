using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public bool IsEnabled { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime Deleted { get; set; }
    }
}
