﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class участники_мероприятия
    {
        [Key][ForeignKey("участники")] public int индекс_участника { get; set; }
        public участники участники { get; set; }
        [Key][ForeignKey("мероприятия")] public int индекс_мероприятия { get; set; }
        public мероприятия мероприятия { get; set; }
    }
}
