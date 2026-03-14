using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] 
    private TMP_Text nameText;

    [SerializeField] 
    private TMP_Text descriptionText;

    [SerializeField] 
    private TMP_Text typeText;

    [SerializeField] 
    private TMP_Text costText;

    [SerializeField] 
    private TMP_Text attText;

    [SerializeField] 
    private TMP_Text defText;

    [SerializeField] 
    private TMP_Text effectText;

    [SerializeField] 
    private Image cardImage;

    [SerializeField] 
    private Image backgroundImage;

    [SerializeField] 
    private Button button;

    [SerializeField] 
    private UIFeedbackTrigger uiFeedbackTrigger;


    private CardData currentData;
    private Language currentLanguage;
    private Theme currentTheme;

    public void Setup(CardData data, Language language, Theme theme)
    {
        if (data == null)
        {
            return;
        }

        currentData = data;
        currentLanguage = language;
        currentTheme = theme;

        if (language != null)
        {
            if (nameText != null)
            {
                nameText.text = language.Get(data.nameLocKey);
            }
            if (descriptionText != null)
            { 
                descriptionText.text = language.Get(data.descriptionLocKey); 
            }
            if (effectText != null)
            {
                effectText.text = language.Get(data.effectLocKey);
            }
        }
        else
        {
            if (nameText != null)
            {
                nameText.text = data.nameLocKey;
            }
            if (descriptionText != null)
            {
                descriptionText.text = data.descriptionLocKey;
            }
            if (effectText != null)
            {
                effectText.text = data.effectLocKey;
            }
        }

        if (typeText != null)
        {
            typeText.text = data.type.ToString();
        }
        if (costText != null)
        {
            costText.text = data.cost.ToString();
        }
        if (attText != null)
        {
            attText.text = data.att.ToString();
        }
        if (defText != null)
        {
            defText.text = data.def.ToString();
        }

        if (cardImage != null)
        {
            cardImage.sprite = data.image;
        }

        if (backgroundImage != null)
        {
            if (data.background != null)
            {
                backgroundImage.sprite = data.background;
            }

            backgroundImage.color = Color.white;
        }

        if (uiFeedbackTrigger != null)
        {
            uiFeedbackTrigger.SetPresets(data.hoverFeedback, data.clickFeedback);
        }

        ApplyTheme(theme);

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnCardClicked);
        }
    }

    private void ApplyTheme(Theme theme)
    {
        if (theme == null) return;
        
        // SPECIAL STYLE (para títulos importantes)
        ApplyTextStyle(nameText, theme.specialFontType, theme.specialFontColor);

        // REGULAR STYLE (para texto normal)
        ApplyTextStyle(descriptionText, theme.regularFontType, theme.regularFontColor);
        ApplyTextStyle(effectText, theme.regularFontType, theme.regularFontColor);
        ApplyTextStyle(typeText, theme.regularFontType, theme.regularFontColor);
        ApplyTextStyle(costText, theme.regularFontType, theme.regularFontColor);
        ApplyTextStyle(attText, theme.regularFontType, theme.regularFontColor);
        ApplyTextStyle(defText, theme.regularFontType, theme.regularFontColor);
    }

    private void ApplyTextStyle(TMP_Text text, TMP_FontAsset font, Color color)
    {
        if (text == null)
        {
            return;
        }

        if (font != null)
        {
            text.font = font;
        }

        text.color = color;
    }

    private void OnCardClicked()
    {
        Debug.Log("Card clicked: " + currentData.nameLocKey);

        CardDetailScreen detailScreen =
            FindFirstObjectByType<CardDetailScreen>(FindObjectsInactive.Include);

        if (detailScreen != null)
        {
            detailScreen.ShowCard(currentData, currentLanguage, currentTheme);
        }
        else
        {
            Debug.LogError("CardDetailScreen not found");
        }
    }

    public void PlaySpecialFeedback()
    {
        if (currentData == null)
        {
            return;
        }

        FeedbackPlayer feedbackPlayer = GetComponent<FeedbackPlayer>();

        if (feedbackPlayer != null && currentData.specialFeedback != null)
        {
            feedbackPlayer.Play(currentData.specialFeedback);
        }
    }

}