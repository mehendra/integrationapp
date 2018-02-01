using System;
using System.Xml.Linq;
using Xero.Api.NetCore;

namespace Initiator.Actioners
{
    public class InvoiceActioner : IActioner
    {
        private IXero xero;

        public InvoiceActioner(IXero xero)
        {
            this.xero = xero;
        }

        public void DisplayCommands()
        {
            Console.WriteLine("2) Invoices");
        }

        public bool AmISelected(string option)
        {
            return "2".Equals(option);
        }

        public string GetName()
        {
            return "Invoice";
        }
        public void RunSubCommands()
        {
            Console.WriteLine("1) Create Invoice by provider id");
            Console.WriteLine("2) Get Invoice for this provider");
            Console.WriteLine("3) Get Invoice for this organisation");
            Console.WriteLine("4) Email this invoice");
        }

        public void Execute(string selectedOption)
        {
            switch (selectedOption)
            {
                case "1":
                    CreateInvoiceForThisProvider();
                    break;
                case "2":
                    GetInvoiceBasedOnProvider(true);
                    break;
                case "3":
                    GetInvoiceBasedOnProvider(false);
                    break;
                case "4":
                    EmailInvoice();
                    break;
                default:
                    Console.WriteLine("Unknown Option");
                    break;
            }
        }

        private void EmailInvoice()
        {
            Console.WriteLine("Please enter the invoice Id: ");
            var invoiceId = Console.ReadLine();
            var invoiceResult = xero.Post(string.Format("invoices/{0}/emails", invoiceId), string.Empty);
            Console.WriteLine(invoiceResult.StatusCode);
            Console.WriteLine(invoiceResult.Body);
        }


        private void GetInvoiceBasedOnProvider(bool useProvider)
        {
            
            var invoiceResponse = xero.Get(string.Format("Invoices?createdByMyApp={0}", useProvider? "true": "false"));
            if (invoiceResponse.StatusCode == "OK")
            {
                var allInvoiceElements = XElement.Parse(invoiceResponse.Body).Element("Invoices").Elements();
                
                foreach (XElement elemenent in allInvoiceElements)
                {
                    Console.WriteLine(elemenent.Element("InvoiceID").Value);
                }
            }
        }

        private void CreateInvoiceForThisProvider()
        {
            XElement element1 = XElement.Parse(@"<Invoices>
                                                  <Invoice>
                                                    <Type>ACCREC</Type>
                                                    <Contact>
                                                      <Name>Xero Mehendra</Name>
                                                      <EmailAddress>mehendra.munasinghe@xero.com</EmailAddress>
                                                    </Contact>
                                                    <Date>2017-08-18T00:00:00</Date>
                                                    <DueDate>2017-08-25T00:00:00</DueDate>
                                                    <LineAmountTypes>Exclusive</LineAmountTypes>
                                                    <LineItems>
                                                      <LineItem>
                                                        <Description>Created by .net Core</Description>
                                                        <Quantity>4.3400</Quantity>
                                                        <UnitAmount>395.00</UnitAmount>
                                                        <AccountCode>200</AccountCode>
                                                      </LineItem>
                                                    </LineItems>
                                                  </Invoice>
                                                </Invoices>");


            XElement element = XElement.Parse(@"<Invoices>
                                                  <Invoice>
                                                    <Type>ACCREC</Type>
                                                    <Contact>
                                                      <Name>Xero Mehendra2</Name>
                                                    </Contact>
                                                    <Date>2017-08-18T00:00:00</Date>
                                                    <DueDate>2017-08-25T00:00:00</DueDate>
                                                    <LineAmountTypes>Exclusive</LineAmountTypes>
                                                    <LineItems>
                                                      <LineItem>
                                                        <Description>Created by .net Core</Description>
                                                        <Quantity>4.3400</Quantity>
                                                        <UnitAmount>395.00</UnitAmount>
                                                        <AccountCode>200</AccountCode>
                                                      </LineItem>
                                                    </LineItems>
                                                  </Invoice>
                                                </Invoices>");
            var invoiceResponse = xero.Put("Invoices", element.ToString());
            if (invoiceResponse.StatusCode == "OK")
            {
                var reposne = XElement.Parse(invoiceResponse.Body);
                var invoiceId = reposne.Element("Invoices").Element("Invoice").Element("InvoiceID").Value;
                Console.WriteLine($"Invoice Created for {invoiceId}");
            }
            else
            {
                Console.WriteLine($"Error code {invoiceResponse.StatusCode}");
            }            
        }
    }
}
