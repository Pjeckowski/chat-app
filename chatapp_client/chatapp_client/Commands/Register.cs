using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace chatapp_client
{
    public class Register : ICommand
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
