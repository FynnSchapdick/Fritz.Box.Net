namespace RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;

[MessageContract(WrapperName = "SetTr069FirmwareDownloadEnabled")]
public readonly record struct ManagementServerSetTr069FirmwareDownloadEnabledRequest(
    [property: MessageBodyMember(Name = "NewTR069FirmwareDownloadEnabled")] bool Tr069FirmwareDownloadEnabled);