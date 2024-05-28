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
    [PrimaryKey(nameof(индекс_собаки), nameof(индекс_выставки))]
    public class собаки_выставки
    {
        [ForeignKey("собаки")] public int индекс_собаки { get; set; }
        [ForeignKey("выставки")] public int индекс_выставки { get; set; }
    }
}
