namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

[MessageContract(WrapperName = "GetTotalPacketsReceivedResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsReceivedResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);