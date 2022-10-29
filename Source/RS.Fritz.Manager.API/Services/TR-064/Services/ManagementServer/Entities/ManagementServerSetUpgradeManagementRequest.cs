namespace RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;

[MessageContract(WrapperName = "SetUpgradeManagement")]
public readonly record struct ManagementServerSetUpgradeManagementRequest(
    [property: MessageBodyMember(Name = "NewUpgradesManaged")] bool UpgradesManaged);