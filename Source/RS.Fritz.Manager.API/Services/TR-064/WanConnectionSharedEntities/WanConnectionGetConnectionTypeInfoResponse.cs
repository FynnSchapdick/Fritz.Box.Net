namespace RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

[MessageContract(WrapperName = "GetConnectionTypeInfoResponse")]
public readonly record struct WanConnectionGetConnectionTypeInfoResponse(
    [property: MessageBodyMember(Name = "NewConnectionType")] string ConnectionType,
    [property: MessageBodyMember(Name = "NewPossibleConnectionTypes")] string PossibleConnectionTypes);