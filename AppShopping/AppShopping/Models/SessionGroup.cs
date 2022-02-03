using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)] //nome e a forma que vai serializar
    public class SessionGroup : List<String>
    {
        [JsonProperty] //atribuindo para que tambem seja serializado
        public string Name { get; set; }

        //ctor - cria construtor
        public SessionGroup(){} //Construtor necessario para deserializar

        public SessionGroup(string name, List<String> list) : base(list)
        {
            Name = name;
        }

        [JsonProperty]
        String[] Items //deixamos evidente a propriedade que o JSON irá utilizar para converter, Vai colocar como uma lista de horarios.
        { 
            get
            {
                return this.ToArray();
            }
            set
            {
                if(value != null)
                    this.AddRange(value);
            } 
        }
    }
}
