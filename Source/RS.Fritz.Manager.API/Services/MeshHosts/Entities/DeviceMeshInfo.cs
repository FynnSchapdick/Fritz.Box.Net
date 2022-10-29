namespace RS.Fritz.Manager.API.Services.MeshHosts.Entities;

public readonly record struct DeviceMeshInfo(string MeshListPath, Uri MeshListPathLink, DeviceMesh DeviceMesh);