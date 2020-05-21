using System.Xml.Serialization;

namespace ChatHeads.Shared.Models
{
    public class Image
    {
        [XmlAttribute(AttributeName = "src")]
        public string Src { get; set; }
        [XmlAttribute(AttributeName = "placement")]
        public string Placement { get; set; }
        [XmlAttribute(AttributeName = "hint-crop")]
        public string Hintcrop { get; set; }
    }
}