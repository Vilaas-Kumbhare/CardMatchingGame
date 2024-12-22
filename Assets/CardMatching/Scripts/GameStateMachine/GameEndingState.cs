using UnityEngine.SceneManagement;


namespace CardMatching.Scripts.StateMachine
{
    public class GameEndingState:IState
    {
        public void Enter()
        {
            Exit();
        }

        public void Execute() { }

        public void Exit()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

