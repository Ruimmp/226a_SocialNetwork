using NUnit.Framework;
using SocialNetworkModel;
using System.Collections.Generic;

namespace TestSocialNetworkModel
{
    [TestFixture]
    public class Tests
    {
        #region private attributes
        Twitter _twitter;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _twitter = new Twitter();
        }

        [Test]
        public void Observers_AfterInstanciationWithoutObservers_Succes()
        {
            //when
            //refere to Setup method
            int exceptedAmountOfObservers = 0;

            //then
            //event is called directly by the assertion

            //when
            Assert.AreEqual(exceptedAmountOfObservers, _twitter.Observers.Count);

        }

        [Test]
        public void Observers_AfterInstanciationWithObservers_Succes()
        {
            //when
            int exceptedAmountOfObservers = 10;
            _twitter = new Twitter(GenerateObserver(exceptedAmountOfObservers));

            //then
            //event is called directly by the assertion

            //when
            Assert.AreEqual(exceptedAmountOfObservers, _twitter.Observers.Count);
        }

        [Test]
        public void Twits_AfterInstanciation_Success()
        {
            //when
            int exceptedAmountOfTwits = 0;
            _twitter = new Twitter();

            //then
            //event is called directly by the assertion

            //when
            Assert.AreEqual(exceptedAmountOfTwits, _twitter.Twits.Count);
        }

        [Test]
        public void Notify_EmptyListOfSubscriber_ThrowsException()
        {
            //given
            //refere to Setup method

            //when
            //event is called directly by the assertion

            //then
            Assert.Throws<EmptyListOfSubscribersException>(delegate { _twitter.Notify(); });
        }

        [Test]
        public void Subscribe_AddFirstSubscribers_Success()
        {
            //given
            //refere to Setup method
            int expectedAmountOfSubscribers = 15;
            List<IObserver> followers = GenerateObserver(expectedAmountOfSubscribers);

            //when
            _twitter.Subscribe(followers);

            //then
            Assert.AreEqual(expectedAmountOfSubscribers, _twitter.Observers.Count);
        }

        [Test]
        public void Subscribe_AddSubscribersToExistingList_Success()
        {
            //given
            //refere to Setup method
            int expectedAmountOfSubscribers = 30;
            List<IObserver> followers = GenerateObserver(expectedAmountOfSubscribers / 2);
            _twitter.Subscribe(followers);
            List<IObserver> followers2nd = GenerateObserver(expectedAmountOfSubscribers / 2);

            //when
            _twitter.Subscribe(followers2nd);

            //then
            Assert.AreEqual(expectedAmountOfSubscribers, _twitter.Observers.Count);
        }

        [Test]
        public void Subscribe_SubscriberAlreadyExists_ThrowsException()
        {
            //given
            //refere to Setup method
            int expectedAmountOfSubscribers = 15;
            List<IObserver> followers = GenerateObserver(expectedAmountOfSubscribers);
            _twitter.Subscribe(followers);
            List<IObserver> followersDuplicate = new List<IObserver> { followers[0] };

            //when
            //event is called directly by the assertion

            //then
            Assert.Throws<SubscriberAlreadyExistsException>(delegate { _twitter.Subscribe(followersDuplicate); });
        }

        [Test]
        public void Unsubscribe_NominalCase_Success()
        {
            //given
            //refer to Setup method
            List<IObserver> followers = GenerateObserver(20);
            _twitter.Subscribe(followers);

            //when
            _twitter.Unsubscribe(followers[10]);

            //then
            Assert.AreEqual(followers.Count, _twitter.Observers.Count - 1);
        }

        [Test]
        public void Unsubscribe_EmptyListOfSubscriber_ThrowsException()
        {
            //given
            //refer to Setup method
            Follower followerToRemove = new Follower();

            //when
            //event is called directly by the assertion

            //then
            Assert.Throws<EmptyListOfSubscribersException>(delegate { _twitter.Unsubscribe(followerToRemove); });
        }

        [Test]
        public void Unsubscribe_SubscriberNotFound_ThrowsException()
        {
            //given
            //refere to Setup method
            IObserver followerNotFound = new Follower();
            _twitter.Subscribe(GenerateObserver(10));

            //when
            //event is called directly by the assertion

            //then
            Assert.Throws<SubscriberNotFoundException>(delegate { _twitter.Unsubscribe(followerNotFound); });
        }

        #region private methods
        private List<IObserver> GenerateObserver(int amountOfObserverToCreate)
        {
            List<IObserver> observers = new List<IObserver>();
            for (int i = 0; i < amountOfObserverToCreate; i++)
            {
                observers.Add(new Follower());
            }
            return observers;
        }
        #endregion private methods
    }
}