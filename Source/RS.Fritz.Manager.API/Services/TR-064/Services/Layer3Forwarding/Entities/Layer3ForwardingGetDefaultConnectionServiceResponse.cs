namespace RS.Fritz.Manager.API.Services.TR_064.Services.Layer3Forwarding.Entities;

[MessageContract(WrapperName = "GetDefaultConnectionServiceResponse")]
public readonly record struct Layer3ForwardingGetDefaultConnectionServiceResponse(
    [property: MessageBodyMember(Name = "NewDefaultConnectionService")] string DefaultConnectionService);