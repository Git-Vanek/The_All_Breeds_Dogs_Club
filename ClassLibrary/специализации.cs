using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class специализации
    {
        [Key] public int индекс_специализации { get; set; }
        public string название { get; set; }
    }
}
