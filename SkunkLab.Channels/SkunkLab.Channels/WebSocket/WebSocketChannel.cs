﻿using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace SkunkLab.Channels.WebSocket
{
    public abstract class WebSocketChannel : IChannel
    {
        public static WebSocketChannel Create(HttpRequestMessage request, WebSocketConfig config, CancellationToken token)
        {
            return new WebSocketServerChannel(request, config, token);
        }

        public static WebSocketChannel Create(Uri endpointUri, WebSocketConfig config, CancellationToken token)
        {
            return new WebSocketClientChannel(endpointUri, config, token);
        }

        public static WebSocketChannel Create(Uri endpointUri, string subProtocol, WebSocketConfig config, CancellationToken token)
        {
            return new WebSocketClientChannel(endpointUri, subProtocol, config, token);
        }

        public static WebSocketChannel Create(Uri endpointUri, string securityToken, string subProtocol, WebSocketConfig config, CancellationToken token)
        {
            return new WebSocketClientChannel(endpointUri, securityToken, subProtocol, config, token);
        }

        public static WebSocketChannel Create(Uri endpointUri, X509Certificate2 certificate, string subProtocol, WebSocketConfig config, CancellationToken token)
        {
            return new WebSocketClientChannel(endpointUri, certificate, subProtocol, config, token);
        }


        public abstract bool IsConnected { get; }

        public abstract string Id { get; internal set; }
        public abstract int Port { get; internal set; }
        public abstract ChannelState State { get; internal set; }

        public abstract bool IsEncrypted { get; internal set; }

        public abstract bool IsAuthenticated { get; internal set; }

        public abstract void Open();

        public abstract event ChannelReceivedEventHandler OnReceive;
        public abstract event ChannelCloseEventHandler OnClose;
        public abstract event ChannelOpenEventHandler OnOpen;
        public abstract event ChannelErrorEventHandler OnError;
        public abstract event ChannelStateEventHandler OnStateChange;
        public abstract event ChannelRetryEventHandler OnRetry;
        public abstract event ChannelSentEventHandler OnSent;

        public abstract Task AddMessageAsync(byte[] message);

        public abstract Task CloseAsync();

        public abstract void Dispose();

        public abstract Task OpenAsync();

        public abstract Task ReceiveAsync();

        public abstract Task SendAsync(byte[] message);

        public abstract void Send(byte[] message);

        
    }
}