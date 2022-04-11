using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heros.Models
{
    public class Hero
    {
        public string Name { get; set; }
        public string History { get; set; }
        public string Skill { get; set; }

        public Hero()
        {
            Name = "";
            History = "";
            Skill = "";
        }




    }
}
