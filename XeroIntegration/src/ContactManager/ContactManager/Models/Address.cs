using System.Xml.Serialization;

namespace ContactManager.Models
{
    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(ElementName = "AddressType")]
        public string AddressType { get; set; }
        [XmlElement(ElementName = "AttentionTo")]
        public string AttentionTo { get; set; }
        [XmlElement(ElementName = "AddressLine1")]
        public string AddressLine1 { get; set; }
        [XmlElement(ElementName = "AddressLine2")]
        public string AddressLine2 { get; set; }
        [XmlElement(ElementName = "AddressLine3")]
        public string AddressLine3 { get; set; }
        [XmlElement(ElementName = "AddressLine4")]
        public string AddressLine4 { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "Region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
    }
}