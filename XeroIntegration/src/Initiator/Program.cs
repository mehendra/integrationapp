using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
//using ContactManager.Models;
using Initiator.Actioners;
using Microsoft.Extensions.Configuration;
using Xero.Api.NetCore;

namespace Initiator
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json");

            var config = builder.Build();

            var xero = new Xero.Api.NetCore.Xero(config);

            while (ContinueToRun(xero))
            {
                Console.WriteLine("----------------");
            }

            Console.WriteLine("All done please hit enter to exit");
            Console.ReadLine();
/*
            var contactHandler = new ContactManager.ContactHandler();
            var c = new Contacts()
            {
                Contact = new Contact
                {
                    Name = "Tony Stark"
                }

            };



            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
            

            using (var sww = new StringWriter())
            {
                
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    x.Serialize(writer, c, xns);
                    var xml = sww.ToString();
                    xero.Put("contacts", xml);
                }
            }

            
            var result = xero.Get("contacts");


            System.Console.WriteLine(result.StatusCode + " : " + result.Body);

            Console.WriteLine(config["Settings:ConsumerKey"]);
            */
        }

        private static bool ContinueToRun(IXero xero)
        {

            var allActioners = new List<IActioner>();
            allActioners.Add(new ContactsActioner(xero));
            allActioners.Add(new InvoiceActioner(xero));



            Console.WriteLine("Select Your Option:");
            foreach (var actioner in allActioners)
            {
                actioner.DisplayCommands();
            }
            var selectedOption = Console.ReadLine();
            IActioner activeActioner = null;
            foreach (var actioner in allActioners)
            {
                if (actioner.AmISelected(selectedOption))
                {
                    activeActioner = actioner;
                    break;
                }
            }
            if (activeActioner != null)
            {
                Console.WriteLine(activeActioner.GetName());
                DisplayTheSecondaryOptions(activeActioner);
            }
            else
            {
                Console.WriteLine("Unknown option");
            }

            Console.WriteLine("Do you wish to continue (y/n) ? ");
        return Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase);

        }

        private static void DisplayTheSecondaryOptions(IActioner activeActioner)
        {
            activeActioner.RunSubCommands();
            var option = Console.ReadLine();
            activeActioner.Execute(option);
        }
    }
}
