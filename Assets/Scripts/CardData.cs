using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public enum CardType
    {
        Attack,
        Defense,
        Utility
    }

    [Header("Localization Keys")]
    public string nameLocKey;
    public string descriptionLocKey;
    public string effectLocKey;


    [Header("Stats")]
    public CardType type;
    public int cost;
    public int att;
    public int def;

    [Header("Visual")]
    public Sprite image;
}