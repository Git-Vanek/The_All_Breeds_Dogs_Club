using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class роли
    {
        [Key] public int индекс_роли { get; set; }
        public string название { get; set; }
        public ICollection<пользователи> пользователи { get; set; }
    }
}
