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
            // Creates CarterCS
            CarterCS carter = new CarterCS();

            //Checks Carters Server Status
            carter.CheckStatus();

            //Get a response from carter 
            //string response = carter.SendMessageToCarter(/* API Key: */ "hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw", /* Message: */ "Hello", /* UserID: */ "admin-1", /* Scene Optional */ "Scene_1");
            //Outputs that response.
            //Console.WriteLine(response);

            //Start conversation with carter
            carter.StartConversationToCarter("hnzD16Ejl0A4WWJsnt96Yz8qE9fs0iNw", "admin-1", "scene-1");
        }
    }
}