using System.Collections.Generic;
using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "Phones")]
    public class Phones
    {
        [XmlElement(ElementName = "Phone")]
        public List<Phone> Phone { get; set; }
    }
}