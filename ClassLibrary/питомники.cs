using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class питомники
    {
        [Key] public int индекс_питомника { get; set; }
        public string название { get; set; }        
        public string телефон { get; set; }
        public string статус { get; set; }
    }
}
