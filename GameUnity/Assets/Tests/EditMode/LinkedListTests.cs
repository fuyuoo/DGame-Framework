using NUnit.Framework;

namespace DGame.Tests
{
    public sealed class LinkedListTests
    {
        [Test]
        public void RemoveThenAddLast_ReusesNodeAndPreservesOrder()
        {
            var list = new DGameLinkedList<int>();
            var removed = list.AddLast(10);
            list.AddLast(20);

            list.Remove(removed);
            Assert.That(list.CacheNodeCount, Is.EqualTo(1));
            Assert.That(removed.Value, Is.EqualTo(0));

            var added = list.AddLast(30);

            Assert.That(added, Is.SameAs(removed));
            Assert.That(list.CacheNodeCount, Is.EqualTo(0));
            Assert.That(list.Count, Is.EqualTo(2));
            CollectionAssert.AreEqual(new[] { 20, 30 }, list);
        }
    }
}
