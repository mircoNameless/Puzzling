using Common;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameOver
{
    public class GameOverMgr : MonoBehaviour
    {

        public Text scoreText;
        public Animator loadingAni;
        public Button againBtn;
        public Button backStartBtn;
        
        public void Start()
        {
            loadingAni.Play("LoadingOpen");
            scoreText.text = GameMgr.Instance.score.ToString();
            againBtn.onClick.AddListener(() =>
            {
                loadingAni.GetComponent<LoadingPage>().sceneCloseEvent = () => { SceneManager.LoadScene("Game"); };
                loadingAni.GetComponent<Animator>().Play("LoadingClose");
            });
            backStartBtn.onClick.AddListener(() => 
            {
                loadingAni.GetComponent<LoadingPage>().sceneCloseEvent = () => { SceneManager.LoadScene("Start"); };
                loadingAni.GetComponent<Animator>().Play("LoadingClose");
            });
        }
    }
}
