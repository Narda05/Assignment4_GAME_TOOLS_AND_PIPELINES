using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FeedbackPlayer : MonoBehaviour
{
    [Header("Preset")]
    public AudioVisualFeedbackPreset preset;

    [Header("UI References")]
    
    [SerializeField] 
    private RectTransform uiTarget;
    
    [SerializeField]
    private Graphic uiGraphic;

    private Vector3 originalScale;
    private Vector2 originalAnchoredPosition;
    private Color originalGraphicColor;

    private void Awake()
    {
        if (uiTarget == null)
        {
            uiTarget = GetComponent<RectTransform>();
        }

        if (uiGraphic == null)
        { 
            uiGraphic = GetComponent<Graphic>();
        }

        if (uiTarget != null)
        {
            originalScale = uiTarget.localScale;
            originalAnchoredPosition = uiTarget.anchoredPosition;
        }

        if (uiGraphic != null)
        {
            originalGraphicColor = uiGraphic.color;
        }
    }

    public void Play()
    {
        Play(preset);
    }

    public void Play(AudioVisualFeedbackPreset targetPreset)
    {
        if (targetPreset == null)
        {
            Debug.LogWarning($"FeedbackPlayer on '{gameObject.name}' has no preset assigned.");
            return;
        }

        PlayAudio(targetPreset);
        PlayAnimations(targetPreset);
    }

    private void PlayAudio(AudioVisualFeedbackPreset targetPreset)
    {
        if (targetPreset == null || targetPreset.fmodEvent.IsNull)
        {
            return;
        }

        EventInstance instance = RuntimeManager.CreateInstance(targetPreset.fmodEvent);
        instance.setPitch(targetPreset.pitch);
        instance.start();
        instance.release();
    }


    private void PlayAnimations(AudioVisualFeedbackPreset targetPreset)
    {
        if (targetPreset.animations == null || targetPreset.animations.Count == 0)
        {
            return;
        }

        ResetVisual();

        foreach (FeedbackAnimation animation in targetPreset.animations)
        {
            if (animation == null || animation.animationType == FeedbackAnimationType.None)
            {
                continue;
            }

            switch (animation.animationType)
            {
                case FeedbackAnimationType.Pop:
                    PlayPop(animation);
                    break;

                case FeedbackAnimationType.Shake:
                    PlayShake(animation);
                    break;

                case FeedbackAnimationType.Flash:
                    PlayFlash(animation);
                    break;
            }
        }
    }
    private void PlayPop(FeedbackAnimation animation)
    {
        if (uiTarget == null)
        {
            return;
        }

        Vector3 targetScale = originalScale * (1f + animation.intensity * 0.08f);

        uiTarget.DOScale(targetScale, animation.duration * 0.5f)
            .SetDelay(animation.delay)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutQuad);
    }

    private void PlayShake(FeedbackAnimation animation)
    {
        if (uiTarget == null)
        {
            return;
        }

        uiTarget.DOShakeAnchorPos(animation.duration, animation.intensity * 12f)
            .SetDelay(animation.delay)
            .SetEase(Ease.OutQuad);
    }

    private void PlayFlash(FeedbackAnimation animation)
    {
        if (uiGraphic == null)
        {
            return;
        }

        Color flashColor = Color.yellow;

        uiGraphic.DOColor(animation.flashColor, animation.duration * 0.5f)
       .SetDelay(animation.delay)
       .SetLoops(2, LoopType.Yoyo)
       .OnComplete(() =>
       {
           if (uiGraphic != null)
           {
               uiGraphic.color = originalGraphicColor;
           }
       });
    }

    public void ResetVisual()
    {
        if (uiTarget != null)
        {
            uiTarget.DOKill();
            uiTarget.localScale = originalScale;
            uiTarget.anchoredPosition = originalAnchoredPosition;
        }

        if (uiGraphic != null)
        {
            uiGraphic.DOKill();
            uiGraphic.color = originalGraphicColor;
        }
    }
}
