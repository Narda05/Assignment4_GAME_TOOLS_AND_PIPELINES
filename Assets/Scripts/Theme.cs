using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "Tuning/Theme")]
public class Theme : ScriptableObject
{
    [Header("Regular Style")]
    public TMP_FontAsset regularFontType;
    public Color regularFontColor = Color.black;
    public Sprite regularButtonStyle;

    [Header("Special Style")]
    public TMP_FontAsset specialFontType;
    public Color specialFontColor = Color.white;
}
