namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

[MessageContract(WrapperName = "GetOnlineMonitor")]
public readonly record struct WanCommonInterfaceConfigGetOnlineMonitorRequest(
    [property: MessageBodyMember(Name = "NewSyncGroupIndex")] uint SyncGroupIndex);