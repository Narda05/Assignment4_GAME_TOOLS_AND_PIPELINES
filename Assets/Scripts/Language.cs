using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Language", menuName = "Scriptable Objects/Language")]


public class Language : ScriptableObject
{
    public enum LanguageType
    {
        EN,
        FR,
        SP
    }

    public LanguageType currentLanguage = LanguageType.EN;
    public List<LocData> entries = new List<LocData>();

    public string Get(string key)
    {
        // Busca el key en la lista
        for (int i = 0; i < entries.Count; i++)
        {
            if (entries[i].locKey == key)
            {
                if (currentLanguage == LanguageType.FR)
                {
                    return entries[i].fr;
                }
                if (currentLanguage == LanguageType.SP)
                {
                    return entries[i].sp;
                }
                return entries[i].en; // EN
            }
        }
        return key;
    }


}
