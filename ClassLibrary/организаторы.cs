using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class организаторы
    {
        [Key] public int индекс_организатора { get; set; }
        public string название { get; set; }
        public string расположение { get; set; }
    }
}
