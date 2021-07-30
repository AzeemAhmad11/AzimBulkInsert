using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BulkInsert.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}
