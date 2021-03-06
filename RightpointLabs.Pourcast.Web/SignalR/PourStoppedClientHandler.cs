﻿namespace RightpointLabs.Pourcast.Web.SignalR
{
    using Microsoft.AspNet.SignalR.Infrastructure;

    using RightpointLabs.Pourcast.Application.Transactions;
    using RightpointLabs.Pourcast.Domain.Events;

    public class KegRemainingChangedClientHandler : IEventHandler<KegRemainingChanged>
    {
        private readonly IConnectionManager _connectionManager;

        public KegRemainingChangedClientHandler(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void Handle(KegRemainingChanged domainEvent)
        {
            var context = _connectionManager.GetHubContext<EventsHub>();

            TransactionExtensions.WaitForTransactionCompleted(() => context.Clients.All.PourStopped(domainEvent));
        }
    }
}