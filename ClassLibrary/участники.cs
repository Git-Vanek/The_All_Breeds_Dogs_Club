using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class участники
    {
        [Key] public int индекс_участника { get; set; }
        public string фамилия { get; set; }
        public string имя { get; set; }
        public string отчество { get; set; }
        public string телефон { get; set; }
        public string эл_почта { get; set; }
        public string паспортные_данные { get; set; }
        public DateTime дата_вступления { get; set; }
        [ForeignKey("пользователи")] public int индекс_пользователя { get; set; }
    }
}
