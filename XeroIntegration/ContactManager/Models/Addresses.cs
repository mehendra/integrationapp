using System.Collections.Generic;
using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "Addresses")]
    public class Addresses
    {
        [XmlElement(ElementName = "Address")]
        public List<Address> Address { get; set; }
    }
}