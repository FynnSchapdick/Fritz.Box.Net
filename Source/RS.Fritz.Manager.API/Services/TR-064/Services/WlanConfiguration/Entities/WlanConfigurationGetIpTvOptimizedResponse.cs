namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetIpTvOptimizedResponse")]
public readonly record struct WlanConfigurationGetIpTvOptimizedResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_IPTVoptimize")] bool IpTvOptimize);