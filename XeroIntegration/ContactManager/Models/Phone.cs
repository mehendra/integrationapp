using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "Phone")]
    public class Phone
    {
        [XmlElement(ElementName = "PhoneType")]
        public string PhoneType { get; set; }
        [XmlElement(ElementName = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [XmlElement(ElementName = "PhoneAreaCode")]
        public string PhoneAreaCode { get; set; }
        [XmlElement(ElementName = "PhoneCountryCode")]
        public string PhoneCountryCode { get; set; }
    }
}