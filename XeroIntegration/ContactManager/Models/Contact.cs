using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "Contact")]
    public class Contact
    {
        [XmlElement(ElementName = "ContactNumber")]
        public string ContactNumber { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "ContactStatus")]
        public string ContactStatus { get; set; }
        [XmlElement(ElementName = "EmailAddress")]
        public string EmailAddress { get; set; }
        [XmlElement(ElementName = "SkypeUserName")]
        public string SkypeUserName { get; set; }
        [XmlElement(ElementName = "BankAccountDetails")]
        public string BankAccountDetails { get; set; }
        [XmlElement(ElementName = "TaxNumber")]
        public string TaxNumber { get; set; }
        [XmlElement(ElementName = "AccountsReceivableTaxType")]
        public string AccountsReceivableTaxType { get; set; }
        [XmlElement(ElementName = "AccountsPayableTaxType")]
        public string AccountsPayableTaxType { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "DefaultCurrency")]
        public string DefaultCurrency { get; set; }
        [XmlElement(ElementName = "Addresses")]
        public Addresses Addresses { get; set; }
        [XmlElement(ElementName = "Phones")]
        public Phones Phones { get; set; }
        [XmlElement(ElementName = "ContactPersons")]
        public ContactPersons ContactPersons { get; set; }
    }
}