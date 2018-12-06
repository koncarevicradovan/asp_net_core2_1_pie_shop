using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Configuration
{
    public class MyOptions
    {
        public MyOptions()
        {
            Title = "some default value";
        }
        public string Title { get; set; }

    }
}
