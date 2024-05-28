using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class результаты_осмотров_собак
    {
        [Key] public int индекс_результата { get; set; }
        [ForeignKey("собаки")] public int индекс_собаки { get; set; }
        public DateTime дата_осмотра { get; set; }
        public string диагноз { get; set; }
        public string статус { get; set; }
        
    }
}
