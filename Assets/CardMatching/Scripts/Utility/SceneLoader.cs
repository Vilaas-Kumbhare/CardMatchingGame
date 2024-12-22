using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardMatching.Scripts.Utility
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
