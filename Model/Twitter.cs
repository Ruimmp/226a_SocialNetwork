using System;
using System.Reflection.Metadata.Ecma335;

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
            if (_observers.Count < 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new EmptyListOfSubscribersException();
            }
        }

        public void Subscribe(List<IObserver> observers)
        {
            if (observers.Intersect(observers).Any())
            { 
                foreach (var observer in observers)
                {
                    if (!_observers.Contains(observer))
                    {
                        _observers.Add(observer);
                    }
                    else
                    {
                        throw new SubscriberAlreadyExistsException();
                    }
                }
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            /*
            if (_observers.Count > 0 && _observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
            else if (!_observers.Contains(observer))
            {
                throw new SubscriberNotFoundException();
            } 
            */

            if (_observers.Count == 0)
            {
                throw new EmptyListOfSubscribersException();
            } 
            else if (!_observers.Remove(observer))
            {
                throw new SubscriberNotFoundException();
            }
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
