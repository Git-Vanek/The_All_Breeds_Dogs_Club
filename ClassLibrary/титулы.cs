using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class титулы
    {
        [Key] public int индекс_титула { get; set; }
        public string название { get; set; }
    }
}
