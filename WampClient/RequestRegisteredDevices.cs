using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2.Client;
using WampSharp.V2.PubSub;
using WampSharp.V2.Core.Contracts;

namespace Wamp.Client
{

    public partial class WampClient
    {
        /***********************************************************************************************************************/
        /********************                     Request all registered devices                             *******************/
        /***********************************************************************************************************************/

        /// <summary>This method will request all registered devices.</summary>
        /// <returns>
        /// The method returns the list of all registered devices. Each element contains the device directory number and the current
        /// connection state reachable / not reachable.
        /// </returns>
 
        /***********************************************************************************************************************/
        public List<wamp_device_registration_element> requestRegisteredDevices()
        /***********************************************************************************************************************/
        {
            object res      = GetSystemDevicesRegistered();
            string json_str = res.ToString();
            OnChildLogString?.Invoke(this, json_str);

            List<wamp_device_registration_element> registeredDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wamp_device_registration_element>>(json_str);
            return registeredDevices;
        }

        /// <summary>
        /// This method requests a list of IP interfaces available on the Zenitel Connect Platform 
        /// </summary>
        /// <returns>The method returns a list of IP interface Ports. Each element contains the MAC-Addres, status and name</returns>
        /***********************************************************************************************************************/
        public List<wamp_interface_list> requestInterfaceList()
        /***********************************************************************************************************************/
        {
            object res = GetInterfaceList();
            string json_str = res.ToString();
            OnChildLogString?.Invoke(this, json_str);

            List<wamp_interface_list> interfaceList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wamp_interface_list>>(json_str);
            return interfaceList;
        }

        /// <summary>
        /// This method requests a list of calls registered at the Zenitel Connect Platform. The returned list may be filtered (reduced)
        /// by specifying the filtering parameters. A filtering parameter not being used is specified as an empty string. 
        /// </summary>
        /// <param name="dirNo">Only return calls having this directory number as member.</param>
        /// <param name="callId">Only return the call having this call identification.</param>
        /// <param name="state">Only return calls being in the specified state.</param>
        /// <returns>The method returns a list of calls according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<wamp_call_element> requestCallList(string dirNo, string callId, string state)
        /***********************************************************************************************************************/
        {
            object res = GET_calls(dirNo, callId, state);
            string json_str = res.ToString();
            OnChildLogString?.Invoke(this, json_str);

            List<wamp_call_element> callList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wamp_call_element>>(json_str);
            return callList;
        }

        /// <summary>
        /// This method requests a list of queued calls registered at the Zenitel Connect Platform. The returned list may be filtered (reduced)
        /// by specifying the filtering parameters. A filtering parameter not being used is specified as an empty string. 
        /// </summary>
        /// <param name="agent">Only return call queues handled by this agent.</param>
        /// <param name="fromDirno">Only return call queues with calls from this directory number.</param>
        /// <param name="queueDirNo">Only return call queue with this directory number.</param>
        /// <returns>The method returns a list of call queues according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<wamp_call_queue_element> requestQueuedCalls(string agent, string fromDirno, string queueDirNo)
        /***********************************************************************************************************************/
        {
            object res = GET_calls_queued(agent, fromDirno, queueDirNo);
            string json_str = res.ToString();
            OnChildLogString?.Invoke(this, json_str);

            List<wamp_call_queue_element> callQueuedList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wamp_call_queue_element>>(json_str);
            return callQueuedList;
        }


        /// <summary>
        /// This method requests a status list of General Purpose Outputs Ports.
        /// </summary>
        /// <param name="device_id">This is the ID of the device having the General Outport Port</param>
        /// <param name="id">This is the name of the General Purpose Outport Port</param>
        /// <returns>The method returns a list of GPO elements according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<wamp_device_gpio_element> requestDevicesGPOs(string device_id, string id)
        /***********************************************************************************************************************/
        {
            object res = GET_devices_gpos(device_id, id);

            if (res != null)
            {
                string json_str = res.ToString();
                OnChildLogString?.Invoke(this, json_str);
                List<wamp_device_gpio_element> gpoElementList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wamp_device_gpio_element>>(json_str);
                return gpoElementList;
            }
            else
            {
                List<wamp_device_gpio_element> gpoElementList = new List<wamp_device_gpio_element>();
                return gpoElementList;
            }
        }

        /// <summary>
        /// This method requests a status list of General Purpose Inputs Ports.
        /// </summary>
        /// <param name="device_id">This is the ID of the device having the General Inport Port</param>
        /// <param name="id">This is the name of the General Purpose Inport Port</param>
        /// <returns>The method returns a list of GPI elements according to the filtering specified via the parameters.</returns>
        /***********************************************************************************************************************/
        public List<wamp_device_gpio_element> requestDevicesGPIs(string device_id, string id)
        /***********************************************************************************************************************/
        {
            object res = GET_devices_gpis(device_id, id);

            if (res != null)
            {
                string json_str = res.ToString();
                OnChildLogString?.Invoke(this, json_str);
                List<wamp_device_gpio_element> gpoElementList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wamp_device_gpio_element>>(json_str);
                return gpoElementList;
            }
            else
            {
                List<wamp_device_gpio_element> gpoElementList = new List<wamp_device_gpio_element>();
                return gpoElementList;
            }
        }

    }
}

