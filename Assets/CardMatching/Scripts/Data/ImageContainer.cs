using UnityEngine;

namespace CardMatching.Scripts.Data
{
    [CreateAssetMenu(fileName = "ImageContainer", menuName = "MatchingCard/CreateContainer")]
    public class ImageContainer : ScriptableObject
    {
        public Sprite[] cardImage;
    }
}
