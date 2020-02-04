using UnityEngine;

namespace Game
{
    public class GameOver : MonoBehaviour
    {
        public void GameOverEvent()
        {
            GameMgr.Instance.loadingPageAni.Play("LoadingClose");
        }
    }
}
