using System.Windows.Controls;
using System.Xml.Serialization;

namespace Game.Models;

public class Card
{
    public string PicturePath { get; init; }

    [XmlIgnore]
    public Button Button { get; set; }

    public int Row { get; set; }
    public int Column { get; set; }
}