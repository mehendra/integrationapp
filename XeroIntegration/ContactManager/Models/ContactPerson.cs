using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "ContactPerson")]
    public class ContactPerson
    {
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "EmailAddress")]
        public string EmailAddress { get; set; }
        [XmlElement(ElementName = "IncludeInEmails")]
        public string IncludeInEmails { get; set; }
    }
}