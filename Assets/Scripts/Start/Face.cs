using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Face : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Animator bubbleAnimator;
    public Image bubbleImg;
    public bool isTouch;

    private void Update()
    {
        BubbleMove();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isTouch = false;
    }

    private void BubbleMove()
    {
        if (isTouch)
        {
            bubbleAnimator.SetBool("touch", true);
            bubbleImg.sprite = Resources.Load<Sprite>("Textures/PuzzleSB2");
        }
        else
        {
            bubbleAnimator.SetBool("touch", false);
            bubbleImg.sprite = Resources.Load<Sprite>("Textures/PuzzleSB1");
        }
    }
}
