using System;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using Trivia;
using Xunit;

namespace Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GameTest
    {
        [Fact]
        public void Test1()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game(new Players(new Player("Cedric")));
            game.HasRolled(2);
            game.AnswerIsWrong();
            game.NextPlayer();
            game.HasRolled(2);
            game.HasRolled(3);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(3);
            Approvals.Verify(fakeconsole.ToString());
        }
        
        [Fact]
        public void Test2()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));
            game.HasRolled(1);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            Approvals.Verify(fakeconsole.ToString());
        }
        
        [Fact]
        public void Test3()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));
            game.HasRolled(1);
            game.AnswerIsWrong();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            game.HasRolled(2);
            game.AnswerIsCorrect();
            game.NextPlayer();
            Approvals.Verify(fakeconsole.ToString());
        }

        [Fact]
        public void Should_not_have_winner_when_game_starts()
        {
            // Arrange
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));

            // Act
            var hasAWinner = game.HasAWinner();

            // Assert
            Assert.False(hasAWinner);
        }

        [Fact]
        public void Should_have_a_winner()
        {
            //Arrange
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));

            // Act
            for (var i = 0; i < 11; i++)
            {
                game.HasRolled(1);
                game.AnswerIsCorrect();
                game.NextPlayer();
            }
            
            var hasAWinner = game.HasAWinner();
            
            // Assert
            Assert.True(hasAWinner);
        }
        
        [Theory]
        [InlineData(12)]
        [InlineData(0)]
        public void Should_throw_error_if_roll_is_not_valid(int roll)
        {
            //Arrange
            var game = new Game(new Players(new Player("Cedric"), new Player("Eloïse")));

            // Act
            Assert.Throws<ArgumentException>(() => game.HasRolled(roll));
        }
    }
}
