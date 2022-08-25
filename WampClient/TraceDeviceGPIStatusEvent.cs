using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2.Client;
using WampSharp.V2.PubSub;
using WampSharp.V2.Core.Contracts;
using System.Runtime.Serialization;

namespace Wamp.Client
{
    public partial class WampConnection
    {
        /***********************************************************************************************************************/
        /********************            Trace Device GPI (General Purpose Input) Status Event               *******************/
        /***********************************************************************************************************************/

        TracerDeviceGPIStatusEvent tracerDeviceGPIStatusEvent = null;
 
        IAsyncDisposable  tracerDeviceGPIStatusEventDisposable = null;

        /// <summary>
        /// If set (not null) GPI (General Purpose Input) changes will be sent to event handler OnWampDeviceGPIStatusEvent
        /// </summary>
        public event EventHandler<wamp_device_gpio_element> OnWampDeviceGPIStatusEvent;


        /***********************************************************************************************************************/
        internal class TraceDeviceGPIOptions : SubscribeOptions
        /***********************************************************************************************************************/
        {
            // Add data members with name corresponding to the option fields (see reference documentation)
            // If a data member is not set, it will not be sent to WAAPI
            [DataMember(Name = "dirno")]
            public string dirno { get; set; }
        }

        /// <summary>
        /// This method enables the subscription of GPI (General Purpose Input) Status Changes.
        /// </summary>
        /// <param name="dirNo">The directory number of the device from where status changes are enabled>
        /// </param>
        /***********************************************************************************************************************/
        public async void TraceDeviceGPIStatusEvent(string dirNo)
        /***********************************************************************************************************************/       
        {
            try
            {
                if ((dirNo != null) && (dirNo.Length > 0))
                {                 
                    TraceDeviceGPIOptions options = new TraceDeviceGPIOptions();
                    options.@dirno = dirNo;

                    string uri = TraceWampDeviceDirnoGpi.Replace("{dirno}", dirNo);

                    IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(uri);

                    tracerDeviceGPIStatusEvent = new TracerDeviceGPIStatusEvent();
                    tracerDeviceGPIStatusEvent.OnDeviceGPIStatusEvent += TracerDeviceGPIStatusEvent_OnDeviceGPIStatusEvent;
                    tracerDeviceGPIStatusEvent.OnDebugString          += TracerDeviceGPIStatusEvent_OnDebugString;

                    tracerDeviceGPIStatusEventDisposable = await topicProxy.Subscribe(tracerDeviceGPIStatusEvent, options).ConfigureAwait(false);
                }
                else
                {
                    OnChildLogString?.Invoke(this, "Illegal dir no in TraceDeviceGPIStatusEven.");
                }
            }

            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception: " + ex.ToString());
            }
        }


        /***********************************************************************************************************************/
        private void TracerDeviceGPIStatusEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "DeviceGPI Status Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerDeviceGPIStatusEvent_OnDeviceGPIStatusEvent(object sender, wamp_device_gpio_element gpioElement)
        /***********************************************************************************************************************/       
        {
            OnWampDeviceGPIStatusEvent?.Invoke(this, gpioElement);
        }


        /// <summary>This method terminates the subscription of GPI (General Purpose Input) Status Updates.</summary>
        /***********************************************************************************************************************/
        public void TraceDeviceGPIStatusEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerDeviceGPIStatusEventDisposable != null)
            {
                tracerDeviceGPIStatusEventDisposable.DisposeAsync();
                tracerDeviceGPIStatusEventDisposable = null;
                tracerDeviceGPIStatusEvent = null;
            }
        }


        /// <summary>This method returns the status of GPI (General Purpose Input) changes subscription.</summary>
        /// <returns>GPI (General Purpose Input) Status change subscription enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceDeviceGPIStatusEventIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerDeviceGPIStatusEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerDeviceGPIStatusEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_device_gpio_element> OnDeviceGPIStatusEvent;
            public event EventHandler<string> OnDebugString;

            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details)
            /***********************************************************************************************************************/
            {
                string txt = "Got event with publication id: " + publicationId.ToString();
                OnDebugString?.Invoke(this, txt);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments)
            /***********************************************************************************************************************/
            {
                string json_str = arguments[0].ToString();
                OnDebugString?.Invoke(this, json_str);

                wamp_device_gpio_element gpioElement = Newtonsoft.Json.JsonConvert.DeserializeObject<wamp_device_gpio_element>(arguments[0].ToString());
                OnDeviceGPIStatusEvent?.Invoke(this, gpioElement);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments,
                                        IDictionary<string, TMessage> argumentsKeywords)
            /***********************************************************************************************************************/
            {
                string txt = "Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords) IS NOT SUPPORTED";
                OnDebugString?.Invoke(this, txt);
            }
        }
    }
}
