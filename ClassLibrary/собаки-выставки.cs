using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class собаки_выставки
    {
        [Key][ForeignKey("собаки")] public int индекс_собаки { get; set; }
        public собаки собаки { get; set; }
        [Key][ForeignKey("выставки")] public int индекс_выставки { get; set; }
        public выставки выставки { get; set; }
    }
}
