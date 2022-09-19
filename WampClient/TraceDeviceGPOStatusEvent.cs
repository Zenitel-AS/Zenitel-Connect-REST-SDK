using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2.Client;
using WampSharp.V2.PubSub;
using WampSharp.V2.Core.Contracts;
using System.Runtime.Serialization;

namespace Wamp.Client
{
    public partial class WampClient
    {
        /***********************************************************************************************************************/
        /********************                    Trace Device GPO Status Event                               *******************/
        /***********************************************************************************************************************/

        TracerDeviceGPOStatusEvent tracerDeviceGPOStatusEvent = null;
 
        IAsyncDisposable  tracerDeviceGPOStatusEventDisposable = null;

        /// <summary>
        /// If set (not null) GPI (General Purpose Output) changes will be sent to event handler OnWampDeviceGPOStatusEvent
        /// </summary>
        public event EventHandler<wamp_device_gpio_element> OnWampDeviceGPOStatusEvent;


        /***********************************************************************************************************************/
        internal class TraceDeviceGPOOptions : SubscribeOptions
        /***********************************************************************************************************************/
        {
            // Add data members with name corresponding to the option fields (see reference documentation)

            // If a data member is not set, it will not be sent to WAAPI
            [DataMember(Name = "dirno")]
            public string dirno { get; set; }
        }


        /// <summary>
        /// This method enables the subscription of GPO (General Purpose Output) Status Changes.
        /// </summary>
        /// <param name="dirNo">The directory number of the device from where status changes are enabled>
        /// </param>
        /***********************************************************************************************************************/
        public async void TraceDeviceGPOStatusEvent(string dirNo)
        /***********************************************************************************************************************/       
        {
            try
            {
                if ((dirNo != null) && (dirNo.Length > 0))
                {
                    TraceDeviceGPOOptions options = new TraceDeviceGPOOptions();
                    options.@dirno = dirNo;

                    string uri = TraceWampDeviceDirnoGpo.Replace("{dirno}", dirNo);

                    IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(uri);

                    tracerDeviceGPOStatusEvent = new TracerDeviceGPOStatusEvent();
                    tracerDeviceGPOStatusEvent.OnDeviceGPOStatusEvent += TracerDeviceGPOStatusEvent_OnDeviceGPOStatusEvent;
                    tracerDeviceGPOStatusEvent.OnDebugString          += TracerDeviceGPOStatusEvent_OnDebugString;

                    tracerDeviceGPOStatusEventDisposable = await topicProxy.Subscribe(tracerDeviceGPOStatusEvent, options).ConfigureAwait(false);
                }
                else
                {
                    OnChildLogString?.Invoke(this, "Illegal dir no in TraceDeviceGPOStatusEven.");
                }
            }

            catch (Exception ex)
            {
                OnChildLogString?.Invoke(this, "Exception: " + ex.ToString());
            }
        }


        /***********************************************************************************************************************/
        private void TracerDeviceGPOStatusEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "DeviceGPO Status Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerDeviceGPOStatusEvent_OnDeviceGPOStatusEvent(object sender, wamp_device_gpio_element gpioElement)
        /***********************************************************************************************************************/       
        {
            OnWampDeviceGPOStatusEvent?.Invoke(this, gpioElement);
        }


        /// <summary>This method terminates the subscription of GPO (General Purpose Output) Status Updates.</summary>
        /***********************************************************************************************************************/
        public void TraceDeviceGPOStatusEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerDeviceGPOStatusEventDisposable != null)
            {
                tracerDeviceGPOStatusEventDisposable.DisposeAsync();
                tracerDeviceGPOStatusEventDisposable = null;
                tracerDeviceGPOStatusEvent = null;
            }
        }


        /// <summary>This method returns the status of GPO (General Purpose Output) changes subscription.</summary>
        /// <returns>GPO (General Purpose Output) Status change subscription enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceDeviceGPOStatusEventIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerDeviceGPOStatusEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerDeviceGPOStatusEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_device_gpio_element> OnDeviceGPOStatusEvent;
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
                OnDeviceGPOStatusEvent?.Invoke(this, gpioElement);
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
