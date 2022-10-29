namespace RS.Fritz.Manager.API.Services.Capture.Entities;

public readonly record struct CaptureInterfaceGroup(string Name, IEnumerable<CaptureInterface> CaptureInterfaces);