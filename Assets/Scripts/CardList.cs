using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardList", menuName = "Scriptable Objects/CardList")]
public class CardList : ScriptableObject
{
    // String list of paths to card data assets
    public List<string> cardResourcePaths = new List<string>();

    private Dictionary<string, CardData> loadedCards = new Dictionary<string, CardData>();
    public CardData GetCard(int index)
    {
        if (index >= cardResourcePaths.Count)
        {
            return null;
        }

        string path = cardResourcePaths[index];

        if (loadedCards.ContainsKey(path))
        {
            return loadedCards[path];
        }

        CardData card = Resources.Load<CardData>(path);

        if (card != null)
        {
            loadedCards.Add(path, card);
        }

        return card;
    }
}
