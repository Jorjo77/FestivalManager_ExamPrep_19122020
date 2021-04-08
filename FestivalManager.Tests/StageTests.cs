// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

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
			Performer performer = new Performer(null, "B", 20);
			Stage stage = new Stage();

			//Act - Assert
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
		}
	}
}