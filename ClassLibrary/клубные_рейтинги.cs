using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class клубные_рейтинги
    {
        [Key] public int индекс_рейтинга { get; set; }
        [ForeignKey("администраторы")] public int индекс_администратора { get; set; }
        public администраторы администраторы { get; set; }
        [ForeignKey("участники")] public int индекс_участника { get; set; }
        public участники участники { get; set; }
        public int баллы { get; set; }
        public DateTime дата_обновления { get; set; }
    }
}
