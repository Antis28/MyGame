using System.IO;
using MyGame.Sources.SaveLoad;
using NSpec;
using NUnit.Framework;

namespace MyGameTest
{
    [TestFixture]
    public class SaveSystemTests : nspec
    {
        private Contexts contexts;
        private SaveSystem system;
        private GameEntity entity;

        private string expectedTitle;

        [SetUp]
        public void Before()
        {
            contexts = Contexts.sharedInstance;
            system = new SaveSystem(contexts);
            entity = contexts.game.CreateEntity();
            expectedTitle = "Person.of.Interest.S04E08.720p.WEB.rus.LostFilm.TV";
        }

        [Test]
        public void WhenAddSettings_DestroyEntity_isDestroyedAdded()
        {
            entity.AddSettings(expectedTitle);

            system.Execute();

            Assert.True(entity.isDestroyed);
        }

        [Test]
        public void WhenAddSettings_ContainLastFileName_lastFileNameExpected()
        {
            entity.AddSettings(expectedTitle);

            Assert.AreEqual(expectedTitle, entity.settings.lastFileName);
        }

        [Test]
        public void WhenAddSettings_FileCreated()
        {
            var expectedFileName = Directory.GetCurrentDirectory() + @"\settings.json";

            entity.AddSettings(expectedTitle);

            system.Execute();

            Assert.True(File.Exists(expectedFileName));
        }
    }
}
