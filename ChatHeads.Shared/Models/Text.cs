using System.Xml.Serialization;

namespace ChatHeads.Shared.Models
{
    [XmlRoot(ElementName = "text")]
    public class Text
    {
        [XmlAttribute(AttributeName = "hint-maxLines")]
        public string HintmaxLines { get; set; }
        [XmlText]
        public string TextContent { get; set; }
    }
}