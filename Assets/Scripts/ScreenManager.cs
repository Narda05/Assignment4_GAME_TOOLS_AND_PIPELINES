using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject playScreen;
    public GameObject cardListScreen;
    public GameObject cardDetailScreen;


    private void Start()
    {
        ShowMain();
    }
    public void ShowMain()
    {
        HideAll();
        if (mainScreen != null)
        {
            mainScreen.SetActive(true);
        }

    }

    public void ShowPlay()
    {
        HideAll();
        if (playScreen != null)
        {
            playScreen.SetActive(true);
        }
    }

    public void ShowCardList()
    {
        HideAll();
        if (cardListScreen != null)
        {
            cardListScreen.SetActive(true);
        }
    }

    public void ShowCardDetail()
    {
        HideAll();
        if (cardDetailScreen != null)
        {
            cardDetailScreen.SetActive(true);
        }
    }
    private void HideAll()
    {
        mainScreen.SetActive(false);
        playScreen.SetActive(false);
        cardListScreen.SetActive(false);
        cardDetailScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}
