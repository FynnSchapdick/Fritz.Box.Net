namespace RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntriesResponse")]
public readonly record struct WanConnectionGetPortMappingNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewPortMappingNumberOfEntries")] ushort PortMappingNumberOfEntries);