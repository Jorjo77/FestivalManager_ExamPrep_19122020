// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void ConstructorShouldInitializeCollections()
        {
            //Arrange
            Song song = new Song("A", new TimeSpan(0, 3, 30));
            Performer performer = new Performer("An", "B", 20);
            Stage stage = new Stage();


            //Act 
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("A", "An B");
            var expectedResult = 1;
            var actualResult = performer.SongList.Count;

            //Assert
            Assert.IsNotNull(stage.Performers);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void PropertyShouldWorksCorrectly()
        {
            //Arrange
            Performer performer = new Performer("An", "B", 20);
            Stage stage = new Stage();

            //Act 
            stage.AddPerformer(performer);


            var expectedResult = 1;
            var actualResult = stage.Performers.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodAddPerformerShouldThrowArgumentNullExceptionIfReceiveNullArgument()
        {
            //Arrange
            Performer performer = null;
            Stage stage = new Stage();

            //Act - Assert
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void MethodAddPerformerShouldThrowArgumentExceptionIfPerformerAgeIsBelow18()
        {
            //Arrange
            Performer performer = new Performer("An", "B", 17);
            Stage stage = new Stage();

            //Act - Assert
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void MethodAddSongShouldThrowArgumentNullExceptionIfReceiveNullArgument()
        {
            //Arrange
            Song song = null;
            Stage stage = new Stage();

            //Act - Assert
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
        }

        [Test]
        public void MethodAddSongShouldThrowArgumentExceptionIfSongDurationIsBelowOneMinet()
        {
            //Arrange
            Song song = new Song("A", new TimeSpan(0, 0, 50));
            Stage stage = new Stage();

            //Act - Assert
            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]

        public void MethodPlayShouldReturnCorrectPerformansAndSongsCount()
        {
            //Arrange
            Song song1 = new Song("A", new TimeSpan(0, 3, 30));
            Song song2 = new Song("B", new TimeSpan(0, 2, 20));
            Performer performer1 = new Performer("An", "B", 20);
            Performer performer2 = new Performer("Ben", "A", 21);
            Stage stage = new Stage();


            //Act 
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSongToPerformer("A", "An B");
            stage.AddSongToPerformer("B", "Ben A");

            var expectedResult = $"{2} performers played {2} songs";
            var actualResult = stage.Play();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddSongToPerformerShouldThrowArgumentExceptionIfSongDoNotExist()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("An", "B", 20);
            stage.AddPerformer(performer);
            Song song = new Song("A", new TimeSpan(0, 3, 30));
           
            //Act - Assert
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("B", "An B"));
        }

        [Test]
        public void AddSongToPerformerShouldThrowArgumentExceptionIfPerformerDoNotExist()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("An", "B", 20);
            stage.AddPerformer(performer);
            Song song = new Song("A", new TimeSpan(0, 3, 30));

            //Act - Assert
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("A", "Ben A"));
        }
    }
}