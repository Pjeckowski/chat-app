using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_client
{
    public class Provider : IProvider
    {
        private ICommand ICommand;

        public Provider(ICommand icommand)
        {
            this.ICommand = icommand;
        }

        public void PrintInfo()
        {
            Debug.WriteLine(ICommand.ToString());
        }
    }
}
