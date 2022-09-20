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
        /// This method is designed to remove a subscriber from the existing list of observers
        /// </summary>
        /// <param name="observer">Observer to remove from the list of observers</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Unsubscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is designed to post a twit
        /// </summary>
        /// <param name="twit">Twit to post</param>
        /// <exception cref="NotImplementedException"></exception>
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
