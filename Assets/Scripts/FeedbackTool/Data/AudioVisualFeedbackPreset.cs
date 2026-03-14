using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "AudioVisualFeedbackPreset", menuName = "Feedback Tool/AudioVisualFeedbackPreset")]
public class AudioVisualFeedbackPreset : ScriptableObject
{
    [Header("Preset Info")]
    public string presetName = "New Feedback Preset";

    [TextArea(2, 4)]
    public string description = "Describe what this preset is used for.";

    public string category = "UI";

    [Header("Usage")]
    public FeedbackTriggerType triggerType = FeedbackTriggerType.Manual;
    public FeedbackTargetType targetType = FeedbackTargetType.UI;

    [Header("FMOD Audio")]
    public EventReference fmodEvent;
    public float pitch = 1f;

    [Header("Animations")]
    public List<FeedbackAnimation> animations = new List<FeedbackAnimation>();

}
