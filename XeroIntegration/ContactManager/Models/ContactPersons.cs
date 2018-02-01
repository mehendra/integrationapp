using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "ContactPersons")]
    public class ContactPersons
    {
        [XmlElement(ElementName = "ContactPerson")]
        public ContactPerson ContactPerson { get; set; }
    }
}