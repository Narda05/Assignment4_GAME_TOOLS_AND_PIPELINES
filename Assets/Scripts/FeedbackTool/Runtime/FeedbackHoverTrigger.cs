using UnityEngine;
using UnityEngine.EventSystems;

public class FeedbackHoverTrigger : MonoBehaviour, IPointerEnterHandler
{
    private FeedbackPlayer feedbackPlayer;

    private void Awake()
    {
        feedbackPlayer = GetComponent<FeedbackPlayer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (feedbackPlayer != null)
        {
            feedbackPlayer.Play();
        }
    }
}
