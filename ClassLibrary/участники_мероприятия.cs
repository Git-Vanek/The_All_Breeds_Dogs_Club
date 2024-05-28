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
    [PrimaryKey(nameof(индекс_участника), nameof(индекс_мероприятия))]
    public class участники_мероприятия
    {
        [Key][ForeignKey("участники")] public int индекс_участника { get; set; }
        [Key][ForeignKey("мероприятия")] public int индекс_мероприятия { get; set; }
    }
}
