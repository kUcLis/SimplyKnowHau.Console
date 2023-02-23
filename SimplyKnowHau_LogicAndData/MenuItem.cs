using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_LogicAndData
{
    public class MenuItem
    {

        public int Id { get; set; }

        public string? MenuString { get; set; }

        public MenuItem(int id, string menustring)
        {
            Id = id;
            MenuString = menustring;
        } 
    }
}
