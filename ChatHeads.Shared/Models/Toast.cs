using System;
using System.Xml.Serialization;

namespace ChatHeads.Shared.Models
{
    [Serializable, XmlRoot("toast")]

    public class Toast
    {
        [XmlElement(ElementName = "visual")]

        public Visual Visual { get; set; }
    }
}