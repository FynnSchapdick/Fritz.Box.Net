﻿namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;

[MessageContract(WrapperName = "GetDnsServers")]
public readonly record struct LanHostConfigManagementGetDnsServersRequest;