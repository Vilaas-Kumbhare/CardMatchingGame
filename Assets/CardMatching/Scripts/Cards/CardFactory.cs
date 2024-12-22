using UnityEngine;

namespace CardMatching.Scripts.Cards
{
    public class CardFactory : ICardFactory
    {
        private GameObject _cardTemplate;

        public CardFactory(GameObject cardTemplate)
        {
            _cardTemplate = cardTemplate;
        }
        public Card CreateCard(Sprite cardImage)
        {
            GameObject cardObject = Object.Instantiate(_cardTemplate);
            Card card = cardObject.GetComponent<Card>();
            card.Initialize(cardImage);
            return card;
        }
    }
}