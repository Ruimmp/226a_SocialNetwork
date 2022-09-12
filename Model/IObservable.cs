using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkModel
{
    public interface IObservable
    {
        //Subscribe an Observer to an Observable
        void Subscribe(List<IObserver> observer);

        //Unsubscribe an Observer from an Observable
        void Unsubscribe(IObserver observer);

        //Notify all Observers about a post, an event and any kind of updates
        void Notify();
    }
}
