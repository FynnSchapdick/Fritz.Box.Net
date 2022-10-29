namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanPppConnection.Entities;

[MessageContract(WrapperName = "GetAutoDisconnectTimeSpanResponse")]
public readonly record struct WanPppConnectionGetAutoDisconnectTimeSpanResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DisconnectPreventionEnable")] bool DisconnectPreventionEnable,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DisconnectPreventionHour")] ushort DisconnectPreventionHour);