using System;

namespace De.HsFlensburg.cstime079.Services.MessageBus
{
    interface IServiceBus
    {
        void Register<TNotification>(object listener, Action action);
        void Send<TNotification>(TNotification notification);
        void Unregister<TNotification>(object listener);
    }
}
