using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wamp.Client
{

    public partial class WampClient
    {
  
        /// <summary>This class contains device registration element.</summary>
        public class wamp_device_registration_element
        {
            /// <summary>
            /// Dirno is the directory number of the device.
            /// </summary>
            public string dirno { get; set; }

            /// <summary>
            /// Location is the where the device is placed.
            /// </summary>
            public string location { get; set; }

            /// <summary>
            /// Name is the assigned name of the device.
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// State indicates if the device is "reachable" or "not reachable".
            /// </summary>
            public string state { get; set; }
        }


        /// <summary>
        /// This class incapsulates the call element
        /// </summary>
        public class wamp_call_element
        {
            /// <summary>
            /// This attribute defines the unique Identification of the call 
            /// </summary>
            public string call_id { get; set; }

            /// <summary>
            /// This attribute defines the unique Identification of the call queueu the call is a member of 
            /// </summary>
            public string call_queueid { get; set; }

            /// <summary>
            /// This attribute defines the type of the call 
            /// </summary>
            public string call_type { get; set; }

            /// <summary>
            /// This attribute defines the caller device of the call 
            /// </summary>
            public string from_dirno { get; set; }

            /// <summary>
            /// This attribute defines the caller device of the call 
            /// </summary>
            public string from_leg_id { get; set; }

            /// <summary>
            /// This attribute defines priority of the call 
            /// </summary>
            public string priority { get; set; }

            /// <summary>
            /// This attribute defines the reason for the call event 
            /// </summary>
            public string reason { get; set; }

            /// <summary>
            /// This attribute defines the calling state of the call 
            /// </summary>
            public string state { get; set; }

            /// <summary>
            /// This attribute defines the called device of the call 
            /// </summary>
            public string to_dirno { get; set; }

            /// <summary>
            /// This attribute defines the called device of the call 
            /// </summary>
            public string to_dirno_current { get; set; }
        }


        /// <summary>
        /// This class defines a call leg
        /// </summary>
        public class wamp_call_leg_element
        {
            /// <summary>
            /// This list defines the directory number of the operators, who can answer a call in the queue. 
            /// </summary>
            public string call_id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string call_type { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string channel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string dirno { get; set; }

            /// <summary>
            /// Defines the directory number of the calling device.
            /// </summary>
            public string from_dirno { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string leg_id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string leg_role { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string priority { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string reason { get; set; }

            /// <summary>
            /// Current state of the call in the queueu (join/leave)
            /// </summary>
            public string state { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string to_dirno { get; set; }
        }


        /// <summary>
        /// This class encapsulates the address information of the Interface List request.
        /// </summary>
         public class  addrInfo
        {
            /// <summary>
            /// IP-Net Broadcast address.
            /// </summary>
            public string broadcast { get; set; }

            /// <summary>
            /// Family name.
            /// </summary>
            public string family { get; set; }

            /// <summary>
            /// Name of the IP port
            /// </summary>
            public string label  { get; set; }

            /// <summary>
            /// IP address of the port.
            /// </summary>
            public string local { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public string preferred_life_time { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public string prefixlen { get; set; }

            /// <summary>
            /// Globel/Link
            /// </summary>
            public string scope { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public string valid_life_time { get; set; }
        }


        /// <summary>
        /// This class encapsulates the IP Interface Status
        /// </summary>
        public class wamp_interface_list
        {
            /// <summary>
            ///  List of available WAMP connections
            /// </summary>
            public List<addrInfo> addr_info { get; set; }

            /// <summary>
            /// MAC-address of the IP port
            /// </summary>
            public string address    { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public string broadcast { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public List<string> flags { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public string group { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public int ifindex { get; set; }

            /// <summary>
            /// Interface name
            /// </summary>
            public string ifname { get; set; }

            /// <summary>
            /// Type of link (ether")
            /// </summary>
            public string link_type { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public int mtu { get; set; }

            /// <summary>
            /// Operational state (UP/DOWN)
            /// </summary>
            public string operstate { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public string qdisc { get; set; }

            /// <summary>
            /// TBD
            /// </summary>
            public int txqlen { get; set; }
        }


        /// <summary>
        /// Class encapsulating the General Purpose I/O element
        /// </summary>
        public class wamp_device_gpio_element
        {
            /// <summary>
            /// Identity of the GPO. The values depend on what the hardware supports and the device configuration. Examples: relay1, gpi4, e_relay1, gpo1
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// The state of the GPO (low/High).
            /// </summary>
            public string state { get; set; }

            /// <summary>
            /// The type of GPO.
            /// </summary>
            public string type { get; set; }
        }


        /// <summary>
        /// This class encapsulates the Open Door Event
        /// </summary>
        public class wamp_open_door_event
        {
            /// <summary>
            /// Caller directory number.
            /// </summary>
            public string from_dirno { get; set; }

            /// <summary>
            /// Name of the caller.
            /// </summary>
            public string from_name { get; set; }

            /// <summary>
            /// Directory number of the device having the door relay.
            /// </summary>
            public string door_dirno { get; set; }

            /// <summary>
            /// Name of the device having the door relay.
            /// </summary>
            public string door_name { get; set; }
        }

        /// <summary>
        /// These enums define the response possible received from the WAMP connection when sending a request
        /// </summary>
        public enum ResponseType
        {
            /// <summary>No Response received from WAMP Connection.</summary>
            WampNoResponce,

            /// <summary>A negative response received from WAMP Connection.</summary>
            WampRequestFailed,

            /// <summary>A positive response received from WAMP Connection.</summary>
            WampRequestSucceeded
        }

        /// <summary>
        /// This class defines the response received from the WAMP connection when sending a request.
        /// </summary>
        public class wamp_response
        {
            /// <summary>
            /// Contains the result of the WAMP request (no response, failed, success)
            /// </summary>
            public ResponseType WampResponse { get; set; }

            /// <summary>
            /// Contains additional information of the request completion
            /// </summary>
            public string CompletionText { get; set; }

            /// <summary>
            /// WAMP Response creator
            /// </summary>
            public wamp_response()
            {
                WampResponse = ResponseType.WampNoResponce;
                CompletionText = "";
            }
        }
    }
}
