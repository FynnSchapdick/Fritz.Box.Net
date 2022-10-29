using RS.Fritz.Manager.API.Services.TR_064.Services.Time.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.Time;

[ServiceContract(Namespace = "urn:dslforum-org:service:Time:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzTimeService
{
    [OperationContract(Action = "urn:dslforum-org:service:Time:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Time:1#SetNTPServers")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest);
}