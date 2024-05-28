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
    [PrimaryKey(nameof(индекс_собаки), nameof(индекс_титула))]
    public class собаки_титулы
    {
        [ForeignKey("собаки")] public int индекс_собаки { get; set; }
        [ForeignKey("титулы")] public int индекс_титула { get; set; }
    }
}
