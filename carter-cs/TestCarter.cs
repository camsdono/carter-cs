using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carter_cs;

namespace carter_cs
{
    class TestCarter
    {
        static public void Main(String[] args)
        {
            CarterCS carter = new CarterCS();
            string response = carter.SendMessageToCarter(/* API Key: */ "hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw", /* Message: */ "Hello", /* UserID: */ "admin-1", /* Scene Optional */ "Scene_1");
            Console.WriteLine(response);
        }
    }
}
