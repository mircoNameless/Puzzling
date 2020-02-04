using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Puzzle : MonoBehaviour
    {
        public PuzzleTypeEnum type;
        public SpriteRenderer puzzleImg;
        public Animator puzzleAni;

        public void SetType(PuzzleTypeEnum typeEnum)
        {
            type = typeEnum;
            ChangePuzzleImg();
            // ChangeAniSpeed();
        }

        private void ChangeAniSpeed()
        {
            // 用此代码可以改变动画播放速度，需要在animator里面设置好变量，然后再在片段里面设置需要改变动画的用上此变量
            puzzleAni.SetFloat("MoveSpeed", 2f);
        }

        private void ChangePuzzleImg()
        {
            if (type == PuzzleTypeEnum.Left)
            {
                puzzleImg.sprite = Resources.Load<Sprite>("Textures/PuzzLeft");
                puzzleAni.SetTrigger("LeftGo");
            }
            else
            {
                puzzleImg.sprite = Resources.Load<Sprite>("Textures/PuzzRight");
                puzzleAni.SetTrigger("RightGo");
            }
        }

        private void CheckPuzzleTrig()
        {
            Player.Instance.PuzzleTrig(type);
            Destroy(gameObject);
        }
    }
}
