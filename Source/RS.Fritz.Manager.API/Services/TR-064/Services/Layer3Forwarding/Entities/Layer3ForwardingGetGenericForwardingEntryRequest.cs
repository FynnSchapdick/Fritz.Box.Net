namespace RS.Fritz.Manager.API.Services.TR_064.Services.Layer3Forwarding.Entities;

[MessageContract(WrapperName = "GetGenericForwardingEntry")]
public readonly record struct Layer3ForwardingGetGenericForwardingEntryRequest(
    [property: MessageBodyMember(Name = "NewForwardingIndex")] ushort ForwardingIndex);