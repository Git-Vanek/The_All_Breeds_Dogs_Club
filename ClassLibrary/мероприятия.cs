using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class мероприятия
    {
        [Key] public int индекс_мероприятия { get; set; }
        [ForeignKey("администраторы")] public int индекс_администратора { get; set; }
        public string название { get; set; }
        public DateTime дата { get; set; }
    }
}
