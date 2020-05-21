using System;
using System.Xml.Serialization;

namespace ChatHeads.Shared.Models
{
    [Serializable, XmlRoot("visual")]
    public class Visual
    {
        [XmlElement(ElementName = "binding")]
        public Binding Binding { get; set; }
    }
}