using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailScreen : MonoBehaviour
{
    [SerializeField] 
    private CardView detailCardView;
    [SerializeField] 
    private Button closeButton;

    public void ShowCard(CardData data, Language language, Theme theme)
    {
        gameObject.SetActive(true);

        if (detailCardView != null)
        {
            FeedbackPlayer feedbackPlayer = detailCardView.GetComponent<FeedbackPlayer>();
            if (feedbackPlayer != null)
            {
                feedbackPlayer.ResetVisual();
            }

            detailCardView.Setup(data, language, theme);
            detailCardView.PlaySpecialFeedback();
        }

        // Apply button style from theme
        if (closeButton != null && theme != null && theme.regularButtonStyle != null)
        {
            closeButton.image.sprite = theme.regularButtonStyle;
        }
    }
    public void Close()
    {
        if (detailCardView != null)
        {
            FeedbackPlayer feedbackPlayer = detailCardView.GetComponent<FeedbackPlayer>();
            if (feedbackPlayer != null)
            {
                feedbackPlayer.ResetVisual();
            }
        }

        gameObject.SetActive(false);
    }
}
