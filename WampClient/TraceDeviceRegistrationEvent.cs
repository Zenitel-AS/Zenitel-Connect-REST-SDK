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
        /********************                 Device Registration Event Subscription                         *******************/
        /***********************************************************************************************************************/

        TracerDeviceRegistrationEvent tracerDeviceRegistrationEvent = null;
        IAsyncDisposable               tracerDeviceRegistrationEventDisposable = null;

        /// <summary>
        /// If set (not null) Device Registration changes will be sent to event handler  OnWampDeviceRegistrationEven
        /// </summary>
        public event EventHandler<wamp_device_registration_element> OnWampDeviceRegistrationEvent;


        /// <summary>
        /// This method enables the subscription of Device Registration Status Changes.
        /// </summary>
        /***********************************************************************************************************************/
        public async void TraceDeviceRegistrationEvent()
        /***********************************************************************************************************************/       
        {
            IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(TraceWampRegisteredDevices);

            tracerDeviceRegistrationEvent = new TracerDeviceRegistrationEvent();
            tracerDeviceRegistrationEvent.OnRegistrationEvent += TracerDeviceRegistrationEvent_OnRegistrationEvent;
            tracerDeviceRegistrationEvent.OnDebugString += TracerDeviceRegistrationEvent_OnDebugString;

            tracerDeviceRegistrationEventDisposable = await topicProxy.Subscribe(tracerDeviceRegistrationEvent, new SubscribeOptions()).ConfigureAwait(false);
        }


        /***********************************************************************************************************************/
        private void TracerDeviceRegistrationEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "Device Registration Subscription Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerDeviceRegistrationEvent_OnRegistrationEvent(object sender, wamp_device_registration_element regUpd)
        /***********************************************************************************************************************/
        {
            OnWampDeviceRegistrationEvent?.Invoke(this, regUpd);
        }

        /// <summary>This method terminates the subscription of Device Registration Status Updates.</summary>
        /***********************************************************************************************************************/
        public void TraceDeviceRegistrationEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerDeviceRegistrationEventDisposable != null)
            {
                tracerDeviceRegistrationEventDisposable.DisposeAsync();
                tracerDeviceRegistrationEventDisposable = null;
                tracerDeviceRegistrationEvent = null;
            }
        }


        /// <summary>This method returns the status of Device Registration changes subscription.</summary>
        /// <returns>DEvice Registration Status change subscription enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceDeviceRegistrationIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerDeviceRegistrationEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerDeviceRegistrationEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_device_registration_element> OnRegistrationEvent;
            public event EventHandler<string> OnDebugString;

            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details)
            /***********************************************************************************************************************/
            {
                OnDebugString?.Invoke(this, "Got event with publication id: " + publicationId);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments)
            /***********************************************************************************************************************/
            {
                string json_str = arguments[0].ToString();
                OnDebugString?.Invoke(this, json_str);

                wamp_device_registration_element regUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<wamp_device_registration_element>(arguments[0].ToString());
                OnRegistrationEvent?.Invoke(this, regUpdate);
            }


            /***********************************************************************************************************************/
            public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments,
                                        IDictionary<string, TMessage> argumentsKeywords)
            /***********************************************************************************************************************/
            {
                OnDebugString?.Invoke(this, "Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords) IS NOT SUPPORTED");
            }

        }
    }
}
