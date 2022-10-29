using System.Runtime.Serialization;

namespace RS.Fritz.Manager.API.Services.TR_064.Services;

[DataContract(Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
public readonly record struct UPnPFault1(
    [property: DataMember(Name = "errorCode")] ushort ErrorCode,
    [property: DataMember(Name = "errorDescription")] string ErrorDescription);