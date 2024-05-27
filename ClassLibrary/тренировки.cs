using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class тренировки
    {
        [Key] public int индекс_тренировки { get; set; }
        public string название { get; set; }
        public DateTime дата { get; set; }
    }
}
