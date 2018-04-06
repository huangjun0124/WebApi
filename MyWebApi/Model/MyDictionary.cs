using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    [Table("MyDictionary", Schema = "dbo")]
    public class MyDictionary
    {
        [Column(@"Key", Order = 1, TypeName = "nvarchar(100)")]
        public string Key { get; set; } // Key (length: 100)

        [Column(@"Value", Order = 2, TypeName = "nvarchar(500)")]
        public string Value { get; set; } // Value (length: 500)
    }
}
