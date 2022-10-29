namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct WlanConfigurationGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent,
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);