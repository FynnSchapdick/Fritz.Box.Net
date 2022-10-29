﻿using System.Xml.Serialization;

namespace RS.Fritz.Manager.API.Services.Users.Entities;

public readonly record struct User(
    [property: XmlAttribute(AttributeName = "last_user")] bool LastUser,
    [property: XmlText] string Name);