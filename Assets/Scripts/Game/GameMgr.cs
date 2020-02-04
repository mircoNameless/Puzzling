using System;
using System.Collections;
using Common;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameMgr : MonoBehaviour
    {
        public static GameMgr Instance;
        
        public Animator loadingPageAni;
        public GameObject puzzlePrefab;
        public Transform incPos;

        public Transform shakeCameraTransform;

        public Animator gameOver;

        public Text scoreText;
        [HideInInspector]
        public int score = 0;

        private void Start()
        {
            Instance = this;
            
            score = 0;
            UpdateScoreText();
            
            loadingPageAni.Play("LoadingOpen");
            loadingPageAni.GetComponent<LoadingPage>().sceneOpenEvent = () => { StartCoroutine( CreatePuzzle()); };
            loadingPageAni.GetComponent<LoadingPage>().sceneCloseEvent = () => { SceneManager.LoadScene("GameOver"); };
        }

        private void CreateNewPuzzle()
        {
            int rangeNum = Random.Range(0, 2);
            GameObject puzzle = Instantiate(puzzlePrefab, incPos.position, Quaternion.identity, incPos);
            puzzle.GetComponent<Puzzle>().SetType(rangeNum == 0 ? PuzzleTypeEnum.Left : PuzzleTypeEnum.Right);
        }

        private float spaceTime = 2.0f;

        private IEnumerator CreatePuzzle()
        {
            yield return new WaitForSeconds(spaceTime);
            CreateNewPuzzle();
            StartCoroutine(CreatePuzzle());
        }
        
        public void AddScore(int num = 1)
        {
            score += num;
            UpdateScoreText();
        }
        public void UpdateScoreText()
        {
            scoreText.text = score.ToString();
        }

        public void GameFail()
        {
            StopAllCoroutines();
            gameOver.Play("GameOver");
        }


        private float shakeTime = 0.2f;
        private float shakeAmount = 3.0f;
        private float shakeSpeed = 2.0f;
        
        private IEnumerator CameraShake()
        {
            Vector3 OrigPosition = shakeCameraTransform.localPosition;
            float ElapsedTime = 0.0f;
            while (ElapsedTime < shakeTime)
            {
                Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere * shakeAmount;
                shakeCameraTransform.localPosition = Vector3.Lerp(shakeCameraTransform.localPosition, RandomPoint, Time.deltaTime * shakeSpeed);
                yield return null;
                ElapsedTime += Time.deltaTime;
            }
            shakeCameraTransform.localPosition = OrigPosition;
        }

        public void Shake()
        {
            StartCoroutine(CameraShake());
        }
    }

    public class HideInSerializeFieldAttribute : Attribute
    {
    }
}
