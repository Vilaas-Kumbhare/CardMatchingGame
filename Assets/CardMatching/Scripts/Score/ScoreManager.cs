using TMPro;
using UnityEngine;

namespace CardMatching.Scripts.Score
{
    public class ScoreManager : MonoBehaviour, IScore
    {
        [SerializeField] private TextMeshProUGUI _userScore;
        [SerializeField] private TextMeshProUGUI _userTurns;

        private int _currentScore;
        private int _noOfTurns;

        private void Awake()
        {
            _currentScore = 0;
            _noOfTurns = 0;
        }

        public void UpdateScore(bool isCorrect)
        {
            if (isCorrect)
                _currentScore++;
            
            _noOfTurns++;

            _userTurns.text = "Score: "+_noOfTurns.ToString();
            _userScore.text = "Turns: "+_currentScore.ToString();
        }
    }
}