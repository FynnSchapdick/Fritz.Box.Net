using System.Xml.Serialization;

namespace RS.Fritz.Manager.API.Services.Users.Entities;

[XmlRoot(ElementName = "List")]
public readonly record struct UserList(
    [property: XmlElement(ElementName = "Username")] User[] Users);