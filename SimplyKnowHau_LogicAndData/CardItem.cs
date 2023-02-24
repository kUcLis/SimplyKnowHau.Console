using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_LogicAndData
{
    public class CardItem
    {
        public int Id { get; set; }

        public string? CardString { get; set; }

        public string? CardContent { get; set; }

        public CardItem(int id, string cardstring)
        {
            Id= id;

            CardString= cardstring; 
        }

        public CardItem(int id, string cardstring, string cardcontent)
        {
            Id = id;

            CardString = cardstring;

            CardContent = cardcontent;
        }
    }
}
