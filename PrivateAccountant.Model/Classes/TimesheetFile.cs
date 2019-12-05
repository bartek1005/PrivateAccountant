using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccountant.Model.Classes
{
    [Table("FDL")]
    public class TimesheetFile
    {

        public int Id { get; set; }
        [Column("PDFFile")]
        public string FileName { get; set; }
        [NotMapped]
        public string FullName { get; set; }
    }
}
