using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class выставки
    {
        [Key] public int индекс_выставки { get; set; }
        public string название { get; set; }
        [ForeignKey("организаторы")] public int индекс_организатора { get; set; }
        public string город { get; set; }
        public string улица { get; set; }
        public string дом { get; set; }
        public DateTime дата { get; set; }
    }
}
