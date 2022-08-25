using System;
using WampSharp.V2.Authentication;
using WampSharp.V2.Client;
using WampSharp.V2.Core.Contracts;


namespace Wamp.Client
{

    /// <summary>
    /// TicketAuthenticator - keeps pair User-Token for WAMP authentication request.
    /// The Token is obtained by REST API login 
    /// </summary>
    internal class TicketAuthenticator : IWampClientAuthenticator
    {

        #region  IWampClientAuthenticator

        // required authentication method is "ticket"
        public string[] AuthenticationMethods => new string[] { "ticket" };

        // AuhenticationId is user name 
        public string AuthenticationId => User;

        // Authenticate is called when session is istablishing
        public AuthenticationResponse Authenticate(string authmethod, ChallengeDetails extra)
        {
            if (authmethod == "ticket")
            {
//                Console.WriteLine("authenticating via '" + authmethod + "'");

                AuthenticationResponse result = new AuthenticationResponse { Signature = Token };

                return result;
            }
            else
            {
                throw new WampAuthenticationException("don't know how to authenticate using '" + authmethod + "'");
            }
        }

        #endregion  IWampClientAuthenticator


        #region properties

        public readonly string User;

        public readonly string Token;

        #endregion properties


        // ctor
        public TicketAuthenticator(string user, string token)
        {
            User = user;
            Token = token;
        }

    }
}
