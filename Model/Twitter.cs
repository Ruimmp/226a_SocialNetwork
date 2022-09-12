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
            _observers = observers;
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

        /// <summary>
        /// This method is designed to trigger update to each subscriber
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Notify()
        {
            if (_observers.Count == 0)
            {
                throw new EmptyListOfSubscribersException();
            }
                
            foreach (IObserver observer in _observers)
            {
                observer.Update(this);
            }
        }

        /// <summary>
        /// This method is designed to add a subscriber in the list of observers
        /// </summary>
        /// <param name="observers">Observers to add to the list of observers</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Subscribe(List<IObserver> observers)
        {
            foreach(IObserver observer in observers)
            {
                if(Exists(observer)){
                    throw new SubscriberAlreadyExistsException();
                }
            }
            _observers.AddRange(observers);
        }

        /// <summary>
        /// This method is designed to add a subscriber in the list of observers
        /// </summary>
        /// <param name="observer">Observer to reomve from the list of observers</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Unsubscribe(IObserver observer)
        {
            if(_observers.Count == 0)
            {
                throw new EmptyListOfSubscribersException();
            }
            if (!Exists(observer))
            {
                throw new SubscriberNotFoundException();
            }
            _observers.Remove(observer);
        }

        public void Post(string twit)
        {
            _twits.Add(twit);
        }

        public string LastTwit
        {
            get 
            {
                return _twits.Last();
            }
        }

        #region private methods
        private bool Exists(IObserver followerToFind)
        {
            foreach (Follower follower in _observers)
            {
                if (follower.Equals(followerToFind))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion private methods
    }

    public class TwitterException : Exception { }
    public class EmptyListOfSubscribersException : TwitterException { }
    public class SubscriberAlreadyExistsException : TwitterException { }
    public class SubscriberNotFoundException : TwitterException { }
}
