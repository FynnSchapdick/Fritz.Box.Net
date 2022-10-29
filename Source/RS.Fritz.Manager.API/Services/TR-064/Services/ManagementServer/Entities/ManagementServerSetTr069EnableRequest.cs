namespace RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;

[MessageContract(WrapperName = "SetTr069Enable")]
public readonly record struct ManagementServerSetTr069EnableRequest(
    [property: MessageBodyMember(Name = "NewTR069Enabled")] bool Tr069Enabled);