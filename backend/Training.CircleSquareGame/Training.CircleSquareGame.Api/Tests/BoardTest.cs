using Xunit;

namespace Training.CircleSquareGame.Api.Tests
{
    public class BoardTest
    {
        [Theory]
        [InlineData("a1", "b1", "c1")]
        [InlineData("a1", "a2", "a3")]
        [InlineData("a1", "b2", "c3")]
        [InlineData("a1", "b1", "c1", "c2", "a2")]
        [InlineData("a1", "b1", "c1", "c3", "c2")]
        public void CheckIfPlayerWon_ReturnsTrue_IfPlayerWon(string val, string val2, string val3, string val4 = null, string val5 = null)
        {
            var sut = new Board();
            var player = PlayerType.X;
            sut.filledFields[player] = new() { val, val2, val3, val4, val5 };
            
            Assert.True(sut.CheckIfPlayerWon(player));
        }        
        
        [Theory]
        [InlineData("a1", "b3", "c1")]
        [InlineData("a1", "b2", "a3")]
        [InlineData("a1", "b2", "b3")]
        public void CheckIfPlayerWon_ReturnsFalse_IfPlayerNotWon(string val, string val2, string val3)
        {
            var sut = new Board();
            var player = PlayerType.X;
            sut.filledFields[player] = new() { val, val2, val3 };
            
            Assert.False(sut.CheckIfPlayerWon(player));
        }
    }
}
