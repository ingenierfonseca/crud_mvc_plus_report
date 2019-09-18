using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    [Table("Form")]
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        public string Name { get; set; }
    }
}
