using MyGame.Sources.SaveLoad;
using NSpec;
using NUnit.Framework;

namespace MyGameTest
{
    [TestFixture]
    public class SaveTests : nspec
    {
        [Test]
        public void WhenExecuting()
        {
            var expected = "Person.of.Interest.S04E08.720p.WEB.rus.LostFilm.TV";
            var contexts = Contexts.sharedInstance;
            var system = new SaveSystem(contexts);
            var ent = contexts.game.CreateEntity();
            ent.AddSettings(expected);

            system.Execute();

            Assert.True(ent.isDestroyed);
            Assert.AreEqual(expected, ent.settings.lastFileName);
        }
    }
}
