using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    [Table("DynamicModule")]
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }
}
