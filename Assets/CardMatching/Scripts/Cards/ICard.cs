using UnityEngine;

namespace CardMatching.Scripts.Cards
{
    public interface ICard
    {
        public void Initialize(Sprite cardImage);
        public void RevealCard();
        public void HideCard();
        public string GetCardType();
    }
}