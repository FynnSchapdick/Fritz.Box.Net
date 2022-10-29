namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

[MessageContract(WrapperName = "GetTotalBytesReceivedResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesReceivedResponse(
    [property: MessageBodyMember(Name = "NewTotalBytesReceived")] uint TotalBytesReceived);