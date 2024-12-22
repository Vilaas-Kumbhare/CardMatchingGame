using System;
using CardMatching.Scripts.Audio;
using UnityEngine;

namespace CardMatching.Scripts.Cards
{
    public class Card : MonoBehaviour,ICard
    {
        public event Action<Card> OnCardRevealed;
        
        [SerializeField]
        private SpriteRenderer _cardImage;
        
        private string _cardType;
        private bool _isCardRevealed;
        private BoxCollider2D _boxCollider2D;

        public void Initialize(Sprite cardImage)
        {
            _cardImage.sprite = cardImage;
            _cardType = cardImage.name;

            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public void RevealCard()
        {
            if (_isCardRevealed) return;
            
            _cardImage.enabled = true;
            _isCardRevealed = true;
            OnCardRevealed?.Invoke(this);
            AudioManager.Instance.PlayAudio("Selected");
        }

        public void HideCard()
        {
            _cardImage.enabled = false;
            _isCardRevealed = false;
        }

        public string GetCardType()
        {
            return _cardType;
        }

        public void OnMouseDown()
        {
            RevealCard();
        }

        public void EnableInteractions(bool enable)
        {
            _boxCollider2D.enabled = enable;
        }
    }
}