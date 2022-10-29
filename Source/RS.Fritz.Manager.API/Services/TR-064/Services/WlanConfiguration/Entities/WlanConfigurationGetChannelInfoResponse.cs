namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetChannelInfoResponse")]
public readonly record struct WlanConfigurationGetChannelInfoResponse(
    [property: MessageBodyMember(Name = "NewChannel")] byte Channel,
    [property: MessageBodyMember(Name = "NewPossibleChannels")] string PossibleChannels);