using MyGame.Sources.Systems;
using NSpec;
using NUnit.Framework;

namespace MyGameTest
{
    [TestFixture]
    public class DestroyDebugTests : nspec
    {
        [Test]
        public void WhenAddDestroyComonent_CountEnteityBellow_ExpectZero()
        {
            var contexts = Contexts.sharedInstance;
            var system = new DestroyDebugSystem(contexts);
            var ent = contexts.debug.CreateEntity();
            ent.isDestroyed = true;

            system.Execute();

            Assert.True(contexts.debug.count == 0);
        }
    }
}
