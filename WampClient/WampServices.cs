using System;
using System.Collections.Generic;
using WampSharp.V2.Rpc;


namespace Wamp.Client
{
    // interface of WAMP services
    internal interface IConnectWampServices
    {
        [WampProcedure(WampClient.GetWampRegisteredDevices)]
        object SystemDevicesRegistered();

        [WampProcedure(WampClient.GetWampInterfaceList)]
        object InterfaceList();

        [WampProcedure(WampClient.GetWampCalls)]
        object GET_calls(string dirNo, string callId, string state);

        [WampProcedure(WampClient.GetCallLegs)]
        object GET_call_legs(string from_dirno, string to_dirno, string dirno, string leg_id, string call_id, string state, string leg_role);

        [WampProcedure(WampClient.GetWampQueues)]
        object GET_call_queues(string queue_dirno);

        [WampProcedure(WampClient.GetWampDevicesGpos)]
        object GET_devices_gpos(string device_id, string id);

        [WampProcedure(WampClient.GetWampDevicesGpis)]
        object GET_devices_gpis(string device_id, string id);
    }


    /// <summary>
    /// The wamp_UCT_time class contains the current UCT-time.
    /// </summary>
    // Publish new UCT time
    public class wamp_UCT_time
    {
        /// <summary>
        /// The newTime is a string containg the current UCT-time.
        /// </summary>
        public string newTime { get; set; }
    }


    // interface of WAMP services
    internal interface IArgumentsService
    {
        [WampProcedure(WampClient.Get_UCT_Time)]
        string Get_UCT_Time();

        // If required - Add additional services here
        // [WampProcedure(WampClient.Get_Audio_Sources)]
        //List<wamp_audio_device_element> Get_Audio_Sources();
    }

    /// <summary>
    /// The ArgumentsService contains the list of services that can be registered.
    /// </summary>
    public class ArgumentsService : IArgumentsService
    {
        /// <summary>
        /// Get_UCT_Time() method returns current UCT-time.
        /// </summary>
        /// <returns>A string containing current UCT-time</returns>
        public string Get_UCT_Time()
        {
            return ("UCT-time: " + DateTime.UtcNow.ToString());
        }


        // Additional example
        //public List<wamp_audio_device_element> Get_Audio_Sources()
        //{

        //    List<wamp_audio_device_element> audDevElementList = new List<wamp_audio_device_element>
        //    {
        //        new wamp_audio_device_element {dirno="101", name="Station 101", type="TCIS-1", gunshot="0.91", glass_break="0.991", stream_port="61150", output_level="10"},
        //        new wamp_audio_device_element {dirno="102", name="Station 102", type="TCIS-1", gunshot="0.92", glass_break="0.992", stream_port="61152", output_level="10"},
        //        new wamp_audio_device_element {dirno="103", name="Station 103", type="TCIS-1", gunshot="0.93", glass_break="0.993", stream_port="61154", output_level="10"},
        //        new wamp_audio_device_element {dirno="104", name="Station 104", type="TCIS-1", gunshot="0.94", glass_break="0.994", stream_port="61156", output_level="10"},
        //        new wamp_audio_device_element {dirno="105", name="Station 105", type="TCIS-1", gunshot="0.95", glass_break="0.995", stream_port="61158", output_level="10"},
        //        new wamp_audio_device_element {dirno="106", name="Station 106", type="TCIS-1", gunshot="0.96", glass_break="0.996", stream_port="61160", output_level="10"},
        //        new wamp_audio_device_element {dirno="107", name="Station 107", type="TCIS-1", gunshot="0.97", glass_break="0.997", stream_port="61162", output_level="10"},
        //        new wamp_audio_device_element {dirno="104", name="Station 108", type="TCIS-1", gunshot="0.98", glass_break="0.998", stream_port="61164", output_level="10"}
        //    };
        //    return audDevElementList;
        //}
    }
}