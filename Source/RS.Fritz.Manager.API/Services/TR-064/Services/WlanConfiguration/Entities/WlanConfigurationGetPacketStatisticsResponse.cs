namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetPacketStatisticsResponse")]
public readonly record struct WlanConfigurationGetPacketStatisticsResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent,
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);