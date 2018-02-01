using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "Contacts")]
    public class Contacts
    {
        [XmlElement(ElementName = "Contact")]
        public Contact Contact { get; set; }
    }
}