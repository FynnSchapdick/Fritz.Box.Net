namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetBasBeaconSecurityPropertiesResponse")]
public readonly record struct WlanConfigurationGetBasBeaconSecurityPropertiesResponse(
    [property: MessageBodyMember(Name = "NewBasicEncryptionModes")] string BasicEncryptionModes,
    [property: MessageBodyMember(Name = "NewBasicAuthenticationMode")] string BasicAuthenticationMode);