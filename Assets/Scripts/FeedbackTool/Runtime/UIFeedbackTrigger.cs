using UnityEngine;
using UnityEngine.EventSystems;

public class UIFeedbackTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Feedback References")]
    [SerializeField]
    private FeedbackPlayer feedbackPlayer;

    [Header("Presets")]
    [SerializeField] 
    private AudioVisualFeedbackPreset hoverPreset;

    [SerializeField] 
    private AudioVisualFeedbackPreset clickPreset;

    private void Awake()
    {
        if (feedbackPlayer == null)
        {
            feedbackPlayer = GetComponent<FeedbackPlayer>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (feedbackPlayer != null && hoverPreset != null)
        {
            feedbackPlayer.Play(hoverPreset);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (feedbackPlayer != null)
        {
            feedbackPlayer.ResetVisual();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (feedbackPlayer != null && clickPreset != null)
        {
            feedbackPlayer.Play(clickPreset);
        }
    }
    public void SetPresets(AudioVisualFeedbackPreset hover, AudioVisualFeedbackPreset click)
    {
        hoverPreset = hover;
        clickPreset = click;
    }
}
