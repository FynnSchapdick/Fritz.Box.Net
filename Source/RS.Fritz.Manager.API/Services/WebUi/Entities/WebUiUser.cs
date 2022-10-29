using System.Xml.Serialization;

namespace RS.Fritz.Manager.API.Services.WebUi.Entities;

public readonly record struct WebUiUser(
    [property: XmlAttribute(AttributeName = "last")] bool LastUser,
    [property: XmlText] string Name);