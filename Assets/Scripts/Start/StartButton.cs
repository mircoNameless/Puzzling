using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Start
{
    public class StartButton : MonoBehaviour
    {
        public Animator loadingP;
        private void Start()
        {
            loadingP.Play("LoadingOpen");
        }

        public void StartBtnClick()
        {
            loadingP.GetComponent<LoadingPage>().sceneCloseEvent = ()=> { SceneManager.LoadScene("Game"); };
            loadingP.Play("LoadingClose");
        }
    }
}
