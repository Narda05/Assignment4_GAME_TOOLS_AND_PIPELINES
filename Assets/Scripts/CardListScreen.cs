using UnityEngine;

public class CardListScreen : MonoBehaviour
{

    [Header("Data (ScriptableObjects)")]
    public CardList cardList;
    public Language language;
    public Theme theme;

    [Header("UI")]
    public Transform contentParent;
    public CardView cardPrefab;

    private void OnEnable()
    {
        BuildList();
    }

    public void BuildList()
    {
        if (cardList == null || contentParent == null || cardPrefab == null)
        {
            Debug.LogError("CardListScreen: Missing references!");
            return;
        }

        Debug.Log("Paths count = " + cardList.cardResourcePaths.Count);

        
        for (int i = contentParent.childCount - 1; i >= 0; i--)
        {
            Destroy(contentParent.GetChild(i).gameObject);
        }

        // Crea cartas nuevas
        for (int i = 0; i < cardList.cardResourcePaths.Count; i++)
        {
            CardData data = cardList.GetCard(i);

            if (data == null)
            {
                Debug.LogWarning("CardData is null at index: " + i);
                continue;
            }

            Debug.Log("Creating UI for: " + data.nameLocKey);

            CardView view = Instantiate(cardPrefab, contentParent);
            view.Setup(data, language, theme);
        }
    }

}
