
namespace Training.CircleSquareGame.Api
{
    public class Board
    {
        public Dictionary<PlayerType, List<string>> filledFields { get; set; }

        private readonly List<string>[] winningCombinations = { new() { "a1", "a2", "a3" }, new() { "b1", "b2", "b3" }, 
                                                                new() { "c1", "c2", "c3" }, new() { "a1", "b1", "c1" }, 
                                                                new() { "a2", "b2", "c2" }, new() { "a3", "b3", "c3" },
                                                                new() { "a1", "b2", "c3" }, new() { "c1", "b2", "a3" }
        };

        public Board()
        {
            filledFields = new()
            {
                { PlayerType.X , new List<string>()},
                { PlayerType.O , new List<string>()}
            };
        }

        public void FillAField(PlayerType playerType, string field)
        {
            filledFields[playerType].Add(field);
        }

        public bool CheckIfPlayerWon(PlayerType playerType)
        {
            if (winningCombinations.Any(comb => comb.All(x => filledFields[playerType].Contains(x)))) return true;
            return false;
        }

        public bool IsFieldFilled(string field)
        {
            var allFilledFields = new List<string>();
            filledFields.Values.ToList().ForEach(x => allFilledFields.AddRange(x));

            return allFilledFields.Contains(field);
        }
    }

}
