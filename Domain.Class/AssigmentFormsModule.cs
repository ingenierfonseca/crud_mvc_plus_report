using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    [Table("AssignmentFormsModule")]
    public class AssigmentFormsModule
    {
        [Key]
        public int AssigmentId { get; set; }
        public int FormId { get; set; }
        public int ModuleId { get; set; }
    }
}
