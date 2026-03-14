using UnityEngine;
using UnityEngine.InputSystem;

public class PlaySpecialFeedback : MonoBehaviour
{
    [SerializeField] private CardView cardView;

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (cardView != null)
            {
                cardView.PlaySpecialFeedback();
            }
        }
    }
}
