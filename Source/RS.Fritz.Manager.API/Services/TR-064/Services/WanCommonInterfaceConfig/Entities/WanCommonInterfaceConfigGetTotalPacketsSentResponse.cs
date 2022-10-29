namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

[MessageContract(WrapperName = "GetTotalPacketsSentResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsSentResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent);