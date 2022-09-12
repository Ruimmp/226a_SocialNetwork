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
                throw new NotImplementedException();
            }
        }        

        /// <summary>
        /// This method is designed to trigger update to each subscriber
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Notify()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is designed to add a subscriber in the list of observers
        /// </summary>
        /// <param name="observers">Observers to add to the list of observers</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Subscribe(List<IObserver> observers)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is designed to add a subscriber in the list of observers
        /// </summary>
        /// <param name="observer">Observer to reomve from the list of observers</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Unsubscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Post(string Twit)
        {
            throw new NotImplementedException();
        }

        public string LastTwit
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        #region private methods
        private bool Exists(Follower followerToFind)
        {
            throw new NotImplementedException();
        }
        #endregion private methods
    }

    public class TwitterException : Exception { }
    public class EmptyListOfSubscribersException : TwitterException { }
    public class SubscriberAlreadyExistsException : TwitterException { }
    public class SubscriberNotFoundException : TwitterException { }
}
