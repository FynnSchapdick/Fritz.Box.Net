namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;

[MessageContract(WrapperName = "GetAddressRangeResponse")]
public readonly record struct LanHostConfigManagementGetAddressRangeResponse(
    [property: MessageBodyMember(Name = "NewMinAddress")] string MinAddress,
    [property: MessageBodyMember(Name = "NewMaxAddress")] string NaxAddress);