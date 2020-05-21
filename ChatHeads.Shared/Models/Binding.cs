using System;
using System.Xml.Serialization;

namespace ChatHeads.Shared.Models
{
    [Serializable, XmlRoot("binding")]
    public class Binding
    {
        [XmlElement(ElementName = "text")]
        public Text Text { get; set; }
        [XmlElement(ElementName = "image")]
        public Image Image { get; set; }
        [XmlAttribute(AttributeName = "template")]
        public string Template { get; set; }
    }
}