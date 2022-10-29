namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

[MessageContract(WrapperName = "GetTotalBytesSentResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesSentResponse(
    [property: MessageBodyMember(Name = "NewTotalBytesSent")] uint TotalBytesSent);