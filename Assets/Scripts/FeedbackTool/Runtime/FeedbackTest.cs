using UnityEngine;
using UnityEngine.InputSystem;

public class FeedbackTest : MonoBehaviour
{
    public FeedbackPlayer feedback;

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (feedback != null)
            {
                feedback.Play();
            }
        }
    }
}
