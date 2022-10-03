using NUnit.Framework;
using SocialNetworkModel;
using System.Collections.Generic;
using static SocialNetworkModel.Twitter;

namespace TestSocialNetworkModel
{
    [TestFixture]
    public class Tests
    {
        #region private attributes
        Twitter? _twitter;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _twitter = new Twitter();
        }

        [Test]
        public void Observers_AfterInstantiationWithoutObservers_Success()
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
        public void Observers_AfterInstantiationWithObservers_Success()
        {
            //when
            int expectedAmountOfObservers = 10;
            _twitter = new Twitter(GenerateObservers(expectedAmountOfObservers));

            //then
            //event is called directly by the assertion

            //when
            Assert.AreEqual(expectedAmountOfObservers, _twitter.Observers.Count);
        }

        [Test]
        public void Twits_AfterInstantiation_Success()
        {
            //when
            int expectedAmountOfTwits = 0;

            //then
            //event is called directly by the assertion

            //when
            Assert.AreEqual(expectedAmountOfTwits, _twitter.Twits.Count);
        }

        [Test]
        public void Notify_EmptyListOfSubscriber_ThrowsException()
        {
            //given
            //refer to Setup method

            //when
            //event is called directly by the assertion

            //then
            Assert.Throws<EmptyListOfSubscribersException>(delegate { _twitter.Notify(); });
        }

        [Test]
        public void Subscribe_AddFirstSubscribers_Success()
        {
            //given
            //refer to Setup method
            int expectedAmountOfSubscribers = 15;
            List<IObserver> followers = GenerateObservers(expectedAmountOfSubscribers);

            //when
            _twitter.Subscribe(followers);

            //then
            Assert.AreEqual(expectedAmountOfSubscribers, _twitter.Observers.Count);
        }

        [Test]
        public void Subscribe_AddSubscribersToExistingList_Success()
        {
            //given
            //refer to Setup method
            int expectedAmountOfSubscribers = 30;
            List<IObserver> followers = GenerateObservers(expectedAmountOfSubscribers / 2);
            _twitter.Subscribe(followers);
            List<IObserver> followersToAdd = GenerateObservers(expectedAmountOfSubscribers / 2);

            //when
            _twitter.Subscribe(followersToAdd);

            //then
            Assert.AreEqual(expectedAmountOfSubscribers, _twitter.Observers.Count);
        }

        [Test]
        public void Subscribe_SubscriberAlreadyExists_ThrowsException()
        {
            //given
            //refer to Setup method
            int expectedAmountOfSubscribers = 15;
            List<IObserver> followers = GenerateObservers(expectedAmountOfSubscribers);
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
            List<IObserver> followers = GenerateObservers(20);
            _twitter.Subscribe(followers);

            //when
            _twitter.Unsubscribe(followers[10]);

            //then
            Assert.AreEqual(followers.Count - 1, _twitter.Observers.Count);
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
            _twitter.Subscribe(GenerateObservers(10));

            //when
            //event is called directly by the assertion

            //then
            Assert.Throws<SubscriberNotFoundException>(delegate { _twitter.Unsubscribe(followerNotFound); });
        }

        #region private methods
        private List<IObserver> GenerateObservers(int amountOfObserverToCreate)
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