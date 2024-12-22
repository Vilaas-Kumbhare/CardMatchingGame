using CardMatching.Scripts.Cards;

namespace CardMatching.Scripts.Board
{
    public interface IBoard
    {
        public void SetUpCardsOnBoard();
        public void HandleCardRevealed(Card card);
        public bool CheckMatch();

        public void HideSelectedCards();
        public void RemoveCardsFromTheBoard();
        public bool AreBothCardsSelected();
        public void HideAllCards();
    }
}