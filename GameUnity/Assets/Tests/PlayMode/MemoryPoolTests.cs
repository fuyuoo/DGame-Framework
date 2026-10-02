using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace DGame.Tests
{
    public sealed class MemoryPoolTests
    {
        public sealed class TestMemory : MemoryObject
        {
            public int Value;
            public int ReleaseCount;

            public override void OnRelease()
            {
                Value = 0;
                ReleaseCount++;
            }
        }

        [UnityTest]
        public IEnumerator ReleaseThenSpawn_ClearsStateAndReusesObject()
        {
            MemoryPool.ClearMemoryCollector<TestMemory>();
            var memory = MemoryPool.Spawn<TestMemory>();
            var current = memory;
            try
            {
                memory.Value = 42;
                yield return null;

                MemoryPool.Release(memory);
                current = null;
                Assert.That(memory.Value, Is.EqualTo(0));
                Assert.That(memory.ReleaseCount, Is.EqualTo(1));

                current = MemoryPool.Spawn<TestMemory>();
                Assert.That(current, Is.SameAs(memory));
                Assert.That(current.Value, Is.EqualTo(0));
            }
            finally
            {
                if (current != null)
                {
                    MemoryPool.Release(current);
                }
                MemoryPool.ClearMemoryCollector<TestMemory>();
            }
        }
    }
}
