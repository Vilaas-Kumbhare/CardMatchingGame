using UnityEngine;

namespace CardMatching.Scripts.Cards
{
    public interface ICardFactory
    {
        public Card CreateCard(Sprite cardImage);
    }
}