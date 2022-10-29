namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetTotalAssociationsResponse")]
public readonly record struct WlanConfigurationGetTotalAssociationsResponse(
    [property: MessageBodyMember(Name = "NewTotalAssociations")] ushort TotalAssociations);