using WampSharp.V2.Rpc;


namespace Wamp.Client
{
    // interface of WAMP services
    internal interface IConnectWampServices
    {
        [WampProcedure(WampConnection.GetWampRegisteredDevices)]
        object SystemDevicesRegistered();


        [WampProcedure(WampConnection.GetWampInterfaceList)]
        object InterfaceList();

        [WampProcedure(WampConnection.GetWampCalls)]
        object GET_calls(string dirNo, string callId, string state);


        [WampProcedure(WampConnection.GetWampQueues)]
        object GET_calls_queued(string agent, string fromDirno, string queueDirNo);


        [WampProcedure(WampConnection.GetWampDevicesGpos)]
        object GET_devices_gpos(string device_id, string id);


        [WampProcedure(WampConnection.GetWampDevicesGpis)]
        object GET_devices_gpis(string device_id, string id);
    }
}