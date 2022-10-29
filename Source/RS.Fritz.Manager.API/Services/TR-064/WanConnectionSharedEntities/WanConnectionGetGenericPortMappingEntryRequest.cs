namespace RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

[MessageContract(WrapperName = "GetGenericPortMappingEntry")]
public readonly record struct WanConnectionGetGenericPortMappingEntryRequest(
    [property: MessageBodyMember(Name = "NewPortMappingIndex")] ushort PortMappingIndex);