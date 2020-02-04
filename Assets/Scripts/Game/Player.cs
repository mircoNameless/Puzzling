using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        public SpriteRenderer playerImg;
        public ParticleSystem winEffect;
        public ParticleSystem dieEffect;
        public GameObject eye01;
        public GameObject eye02;
        public GameObject eye03;
        
        public Button rightBtn;
        public Button leftBtn;
        
        private PuzzleTypeEnum type;
        
        
        private void Start()
        {
            Instance = this;
            rightBtn.onClick.AddListener(() =>
            {
                SetPlayerPuzzleState(PuzzleTypeEnum.Right);
            });
            leftBtn.onClick.AddListener(() =>
            {
                SetPlayerPuzzleState(PuzzleTypeEnum.Left);
            });
        }

        // private void Update()
        // {
        //     if (Input.GetKey(KeyCode.A))
        //     {
        //         SetPlayerPuzzleState(PuzzleTypeEnum.Left);
        //     }
        //     else if (Input.GetKey(KeyCode.D))
        //     {
        //         SetPlayerPuzzleState(PuzzleTypeEnum.Right);
        //     }
        //     else
        //     {
        //         SetPlayerPuzzleState(PuzzleTypeEnum.Normal);
        //     }
        // }

        private void SetPlayerPuzzleState(PuzzleTypeEnum typeEnum)
        {
            type = typeEnum;
            if (type == PuzzleTypeEnum.Left)
            {
                playerImg.sprite = Resources.Load<Sprite>("Textures/PlayerLeft");
            }
            else if (type == PuzzleTypeEnum.Normal)
            {
                playerImg.sprite = Resources.Load<Sprite>("Textures/PlayerIdle");
            }
            else
            {
                playerImg.sprite = Resources.Load<Sprite>("Textures/PlayerRight");
            }
        }

        public void PuzzleTrig(PuzzleTypeEnum typeEnum)
        {
            if (type == typeEnum)
            {
                SetPlayerFaceShow(false, true, false);
                GameMgr.Instance.AddScore();
                winEffect.Play();
            }
            else
            {
                SetPlayerFaceShow(false, false, true);
                GameMgr.Instance.GameFail();
                dieEffect.Play();
            }
            GameMgr.Instance.Shake();
        }
        
        public void SetPlayerFaceShow(bool eye1, bool eye2, bool eye3)
        {
            eye01.SetActive(eye1);
            eye02.SetActive(eye2);
            eye03.SetActive(eye3);
        }
    }
}