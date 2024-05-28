using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    [PrimaryKey(nameof(индекс_результата), nameof(индекс_ветеринара))]
    public class результаты_осмотров_собак_ветерин
    {
        [ForeignKey("результаты_осмотров_собак")] public int индекс_результата { get; set; }
        [ForeignKey("ветеринары")] public int индекс_ветеринара { get; set; }
    }
}
