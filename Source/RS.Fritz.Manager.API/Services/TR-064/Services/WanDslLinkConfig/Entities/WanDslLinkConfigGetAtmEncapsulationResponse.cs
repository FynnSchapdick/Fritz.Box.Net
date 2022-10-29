namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig.Entities;

[MessageContract(WrapperName = "GetAtmEncapsulationResponse")]
public readonly record struct WanDslLinkConfigGetAtmEncapsulationResponse(
    [property: MessageBodyMember(Name = "NewATMEncapsulation")] string AtmEncapsulation);