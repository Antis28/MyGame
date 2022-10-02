using MyGame.Sources.SaveLoad;
using NSpec;
using NUnit.Framework;

namespace MyGameTest
{
    [TestFixture]
    public class LoadSettingsTest : nspec
    {
        private Contexts contexts;
        private LoadSettingsSystem system;
        private GameEntity entity;
        private string expectedTitle;

        [SetUp]
        public void Before()
        {
            contexts = Contexts.sharedInstance;
            system = new LoadSettingsSystem(contexts);
            entity = contexts.game.CreateEntity();
            entity.isLoadSettings = true;
            expectedTitle = "Person.of.Interest.S04E08.720p.WEB.rus.LostFilm.TV";
        }

        [Test]
        public void WhenAddLoadedSettings_ContainLastFileName_lastFileNameExpected()
        {
            var g = contexts.debug.GetGroup(DebugMatcher.DebugLog);
            Assert.AreEqual(0, g.count);
            system.Execute();
            g = contexts.debug.GetGroup(DebugMatcher.DebugLog);
            Assert.AreEqual(1, g.count);
        }
    }
}
