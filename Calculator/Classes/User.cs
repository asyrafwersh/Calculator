using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Calculator.Classes
{
    public class User : BaseDataModel
    {
        [Index(IsUnique = true), Required]
        public string username { get; set; }
    }
}
