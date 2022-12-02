using System;

namespace cs4125.Models
{
    public interface IEvent
    {
        void RegisterObserver(IProfile observer);
        void RemoveObserver(IProfile observer);
        void NotifyObservers();
        void NotifyObserversCancelled();
    }
}