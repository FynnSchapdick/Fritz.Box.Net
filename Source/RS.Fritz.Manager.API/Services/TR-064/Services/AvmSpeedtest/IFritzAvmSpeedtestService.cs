using RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest;

[ServiceContract(Namespace = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzAvmSpeedtestService
{
    [OperationContract(Action = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest);
}