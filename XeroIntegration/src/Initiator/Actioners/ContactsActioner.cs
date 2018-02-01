using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xero.Api.NetCore;

namespace Initiator.Actioners
{
    public class ContactsActioner : IActioner
    {
        private IXero xero;

        public ContactsActioner(IXero xero)
        {
            this.xero = xero;
        }

        public void DisplayCommands()
        {
            Console.WriteLine("1) Contacts");
        }

        public bool AmISelected(string option)
        {
            return "1".Equals(option);
        }

        public string GetName()
        {
            return "Contacts";
        }

        public void RunSubCommands()
        {
            Console.WriteLine("1) Create Contacts");
            Console.WriteLine("2) Get Contacts");
        }

        public void Execute(string selectedOption)
        {
            switch (selectedOption)
            {
                case "1":
                    break;
                case "2":
                    GetContacts();
                    break;
                default:
                    Console.WriteLine("Unknown Option");
                    break;
            }
        }

        private void GetContacts()
        {
            var result = xero.Get("contacts?where=ContactNumber%3D%3D%22UNKNOWN%22");
            Console.WriteLine(result.Body);
        }
    }

    public interface IActioner
    {
        void DisplayCommands();

        bool AmISelected(string option);

        string GetName();

        void RunSubCommands();

        void Execute(string selectedOption);
    }
}
