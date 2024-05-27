using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class клубные_новости
    {
        [Key] public int индекс_новости { get; set; }
        [ForeignKey("администраторы")] public int индекс_администратора { get; set; }
        public администраторы администраторы { get; set; }
        public string заголовок { get; set; }
        public string ссылка_на_файл { get; set; }
        public DateTime дата_публикации { get; set; }
    }
}
