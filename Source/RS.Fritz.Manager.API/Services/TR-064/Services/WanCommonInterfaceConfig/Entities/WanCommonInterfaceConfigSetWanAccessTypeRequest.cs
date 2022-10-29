namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

[MessageContract(WrapperName = "SetWanAccessType")]
public readonly record struct WanCommonInterfaceConfigSetWanAccessTypeRequest(
    [property: MessageBodyMember(Name = "NewAccessType")] string AccessType);