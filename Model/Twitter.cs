namespace SocialNetworkModel
{
    public class Twitter : IObservable
    {
        #region private attributes
        private List<IObserver> _observers = new List<IObserver>();
        private List<String> _twits = new List<String>();
        #endregion private attributes

        public Twitter() { }

        public Twitter(List<IObserver> observers)
        {
            _observers.AddRange(observers);
        }
        
        public List<IObserver> Observers
        {
            get
            {
                return _observers;
            }
        }

        public List<String> Twits
        {
            get
            {
                return _twits;
            }
        }        

        public void Notify()
        {
            throw new EmptyListOfSubscribersException();
        }

        public void Subscribe(List<IObserver> observers)
        {
            if (_observers.Intersect(observers).Any())
            {
                throw new SubscriberAlreadyExistsException();
            }
            else
            {
                _observers.AddRange(observers);
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            if (_observers.Count == 0) throw new EmptyListOfSubscribersException();
            if (!_observers.Remove(observer)) throw new SubscriberNotFoundException();
        }

        public void Post(string twit)
        {
            throw new NotImplementedException();
        }

        public void Remove(IObserver twit)
        {
            if (_twits.Count == 0) throw new EmptyListOfTwitsException();
        }

        public string LastTwit
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        #region private methods
        private bool Exists(IObserver followerToFind)
        {
            throw new NotImplementedException();
        }
        #endregion private methods


        public class TwitterException : Exception { }
        public class EmptyListOfSubscribersException : TwitterException { }
        public class SubscriberAlreadyExistsException : TwitterException { }
        public class SubscriberNotFoundException : TwitterException { }
        public class EmptyListOfTwitsException : TwitterException { }
    }
}