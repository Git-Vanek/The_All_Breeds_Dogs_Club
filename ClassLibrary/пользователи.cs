using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class пользователи
    {
        [Key] public int индекс_пользователя { get; set; }
        public string имя_пользователя { get; set; }
        public string пароль { get; set; }
        public string соль { get; set; }
        [ForeignKey("роли")] public int индекс_роли { get; set; }
    }
}
