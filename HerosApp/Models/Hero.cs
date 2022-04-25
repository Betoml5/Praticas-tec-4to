using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosApp.Models
{
    public class Hero
    {
        public string Name { get; set; }
        public string? Age { get; set; }
        public string Skill { get; set; }

        public string? Image { get; set; }

        public Hero()
        {
            Name = "";
            Skill = "";

        }
    }
}
