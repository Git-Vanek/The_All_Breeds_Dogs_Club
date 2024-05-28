using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class собаки
    {
        [Key] public int индекс_собаки { get; set; }
        [ForeignKey("питомники")] public int индекс_питомника { get; set; }
        public string имя { get; set; }
        public string кличка { get; set; }
        [ForeignKey("породы")] public int индекс_породы { get; set; }
        public string пол { get; set; }
        public string номер { get; set; }
        public DateTime дата_рождения { get; set; }
        public DateTime дата_последней_прививки { get; set; }
    }
}
