using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Calculator.Classes
{
    public class Data : BaseDataModel
    {
        [Index(IsUnique = true), Required]
        public Guid usernameID { get; set; }
        public string result { get; set; }
    }
}
