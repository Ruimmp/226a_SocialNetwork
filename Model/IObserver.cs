using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkModel
{
    public interface IObserver
    {
        //Receive update from the observable
        void Update(IObservable observable);
    }
}
