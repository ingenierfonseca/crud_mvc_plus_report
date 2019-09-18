using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crud_mvc_plus_report.Models
{
    public class ModuleForms
    {
        public int AssigmentId { get; set; }
        public int ModuleId { get; set; }
        public string NameModule { get; set; }
        public int FormId { get; set; }
        public string NameForm { get; set; }
    }
}