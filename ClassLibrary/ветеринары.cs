using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ветеринары
    {
        [Key] public int индекс_ветеринара { get; set; }
        public string фамилия { get; set; }
        public string имя { get; set; }
        public string отчество { get; set; }
        public string телефон { get; set; }
        public string эл_почта { get; set; }
        public string паспортные_данные { get; set; }
        [ForeignKey("специализации")] public int индекс_специализации { get; set; }
        public bool лицензия { get; set; }
        public DateTime дата_трудоустройства { get; set; }
        [ForeignKey("пользователи")] public int индекс_пользователя { get; set; }
    }
}
