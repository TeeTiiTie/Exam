using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Entity
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The field with name {0} is required")]
        public string Name { get; set; }
    }
    
    public class ItemUpdate
    {
        public string Name { get; set; }
    }

}
