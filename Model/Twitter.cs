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
            throw new NotImplementedException();
        }
        
        public List<IObserver> Observers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<String> Twits
        {
            get
            {
                throw new NotImplementedException();
            }
        }        

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(List<IObserver> observers)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Post(string twit)
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
        private bool Exists(IObserver followerToFind)
        {
            throw new NotImplementedException();
        }
        #endregion private methods


        public class TwitterException : Exception { }
        public class EmptyListOfSubscribersException : TwitterException { }
        public class SubscriberAlreadyExistsException : TwitterException { }
        public class SubscriberNotFoundException : TwitterException { }
    }


}
