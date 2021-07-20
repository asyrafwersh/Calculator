using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Calculator.Classes
{
    public class BaseDataModel
    {
        [Key, Required]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
