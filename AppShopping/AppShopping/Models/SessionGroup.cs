using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Models
{
    public class SessionGroup : List<String>
    {
        public string Name { get; set; }

        //ctor - cria construtor
        public SessionGroup(string name, List<String> list) : base(list)
        {
            Name = name;
        }
    }
}
