using UnityEngine;
using UnityEngine.UI;

public class CardDetailScreen : MonoBehaviour
{
    [SerializeField] private CardView detailCardView;
    [SerializeField] private Button closeButton;

    public void ShowCard(CardData data, Language language, Theme theme)
    {
        gameObject.SetActive(true);

        if (detailCardView != null)
        {
            detailCardView.Setup(data, language, theme);
        }

        // Apply button style from theme
        if (closeButton != null && theme != null && theme.regularButtonStyle != null)
        {
            closeButton.image.sprite = theme.regularButtonStyle;
        }

    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
