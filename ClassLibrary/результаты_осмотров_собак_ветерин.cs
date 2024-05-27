using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class результаты_осмотров_собак_ветерин
    {
        [Key] [ForeignKey("результаты_осмотров_собак")] public int индекс_результата { get; set; }
        public результаты_осмотров_собак результаты_осмотров_собак { get; set; }
        [Key][ForeignKey("ветеринары")] public int индекс_ветеринара { get; set; }
        public ветеринары ветеринары { get; set; }
    }
}
