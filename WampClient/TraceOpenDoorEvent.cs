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
        /********************                         Trace Open Door Event                                  *******************/
        /***********************************************************************************************************************/

        TracerOpenDoorEvent tracerOpenDoorEvent = null;
 
        IAsyncDisposable  tracerOpenDoorEventDisposable = null;

        /// <summary>
        /// If set (not null) Open Door Event will be sent to event handler OnWampOpenDoorEvent
        /// </summary>
        public event EventHandler<wamp_open_door_event> OnWampOpenDoorEvent;


        /// <summary>
        /// This method enables the subscription of Open Door Activation Event.
        /// </summary>
        /***********************************************************************************************************************/
        public async void TraceOpenDoorEvent()
        /***********************************************************************************************************************/       
        {
            IWampTopicProxy topicProxy = _wampRealmProxy.TopicContainer.GetTopicByUri(TraceWampSystemOpenDoor);

            tracerOpenDoorEvent = new TracerOpenDoorEvent();
            tracerOpenDoorEvent.OnOpenDoorEvent += TracerOpenDoorEvent_OnOpenDoorEvent;
            tracerOpenDoorEvent.OnDebugString += TracerOpenDoorEvent_OnDebugString;

            tracerOpenDoorEventDisposable = await topicProxy.Subscribe(tracerOpenDoorEvent, new SubscribeOptions()).ConfigureAwait(false);
        }


        /***********************************************************************************************************************/
        private void TracerOpenDoorEvent_OnDebugString(object sender, string e)
        /***********************************************************************************************************************/
        {
            OnChildLogString?.Invoke(this, "Call Subscription Event: " + e);
        }


        /***********************************************************************************************************************/
        private void TracerOpenDoorEvent_OnOpenDoorEvent(object sender, wamp_open_door_event openDoorEvent)
        /***********************************************************************************************************************/       
        {
            OnWampOpenDoorEvent?.Invoke(this, openDoorEvent);
        }


        /// <summary>This method terminates the subscription ofOpen Door Event.</summary>
        /***********************************************************************************************************************/
        public void TraceOpenDoorEventDispose()
        /***********************************************************************************************************************/
        {
            if (tracerOpenDoorEventDisposable != null)
            {
                tracerOpenDoorEventDisposable.DisposeAsync();
                tracerOpenDoorEventDisposable = null;
                tracerOpenDoorEvent = null;
            }
        }


        /// <summary>This method returns the status of the Open Door Event subscription.</summary>
        /// <returns>Open Door Subscription Event enabled/disabled as true/false.</returns>
        /***********************************************************************************************************************/
        public bool TraceOpenDoorEventIsEnabled()
        /***********************************************************************************************************************/
        {
            if (tracerOpenDoorEvent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /***********************************************************************************************************************/
        internal class TracerOpenDoorEvent : IWampRawTopicClientSubscriber
        /***********************************************************************************************************************/
        {

            public event EventHandler<wamp_open_door_event> OnOpenDoorEvent;
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

                wamp_open_door_event openDoorEvent = Newtonsoft.Json.JsonConvert.DeserializeObject<wamp_open_door_event>(arguments[0].ToString());
                OnOpenDoorEvent?.Invoke(this, openDoorEvent);
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
