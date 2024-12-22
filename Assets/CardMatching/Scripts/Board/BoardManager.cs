using System.Collections.Generic;
using UnityEngine;
using CardMatching.Scripts.Cards;
using CardMatching.Scripts.Data;
using CardMatching.Scripts.Grid;
using CardMatching.Scripts.Utility;

namespace CardMatching.Scripts.Board
{
    public class BoardManager : MonoBehaviour,IBoard
    {
        [SerializeField] private Transform _gridLayout;
        [SerializeField] private ImageContainer _cardSpriteContainer;
        [SerializeField] private GameObject _cardTamplate;

        private readonly List<Card> _cards = new List<Card>();
        private Card _firstCard;
        private Card _secondCard;
        


        public void SetUpCardsOnBoard()
        {
            CardFactory cardFactory = new CardFactory(_cardTamplate);
            foreach (Sprite sprite in _cardSpriteContainer.cardImage)
            {
                Card card1 = cardFactory.CreateCard(sprite);
                Card card2 = cardFactory.CreateCard(sprite);
    
                card1.OnCardRevealed += HandleCardRevealed;
                card2.OnCardRevealed += HandleCardRevealed;
    
                _cards.Add(card1);
                _cards.Add(card2);
            }
    
            _cards.Shuffle();

            IGridGenerator gridGenerator = new GridGenerator(_cards, 4, 4, 2.2f);
            gridGenerator.GenerateGrid(_gridLayout);
        }
        
        public void HandleCardRevealed(Card revealedCard)
        {
            if (_firstCard == null)
            {
                _firstCard = revealedCard;
                revealedCard.RevealCard();
            }
            else if (_secondCard == null)
            {
                _secondCard = revealedCard;
                revealedCard.RevealCard();
            }
        }

        public bool CheckMatch()
        {
            if (_firstCard.GetCardType() == _secondCard.GetCardType())
            {
                return true;
            }

            return false;
        }

        public void HideSelectedCards()
        {
            _firstCard.HideCard();
            _secondCard.HideCard();
            _firstCard = null;
            _secondCard = null;
        }

        public void RemoveCardsFromTheBoard()
        {
            _cards.Remove(_firstCard);
            _cards.Remove(_secondCard);
            Destroy(_firstCard.gameObject);
            Destroy(_secondCard.gameObject);
        }

        public bool AreBothCardsSelected()
        {
            return _firstCard != null && _secondCard != null;
        }

        public bool IsBoardCompleted()
        {
            return !(_cards.Count > 0);
        }

        public void HideAllCards()
        {
            foreach (var card in _cards)
            {
                card.HideCard();
            }
        }

        public void EnableBoardCardInteraction(bool enable)
        {
            foreach (var card in _cards)
            {
                card.EnableInteractions(enable);
            }
        }
    }
}