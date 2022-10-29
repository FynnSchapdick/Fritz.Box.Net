﻿namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;

[MessageContract(WrapperName = "GetCurrentUserResponse")]
public readonly record struct LanConfigSecurityGetCurrentUserResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CurrentUsername")] string CurrentUsername,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CurrentUserRights")] string CurrentUserRights);