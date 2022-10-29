namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig.Entities;

[MessageContract(WrapperName = "GetAutoConfigResponse")]
public readonly record struct WanDslLinkConfigGetAutoConfigResponse(
    [property: MessageBodyMember(Name = "NewAutoConfig")] bool AutoConfig);