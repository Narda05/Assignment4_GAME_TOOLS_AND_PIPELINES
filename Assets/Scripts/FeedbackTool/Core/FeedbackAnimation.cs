using UnityEngine;
using System;

[Serializable]
public class FeedbackAnimation
{
    [Header("Animation Settings")]
    public FeedbackAnimationType animationType = FeedbackAnimationType.None;

    [Min(0f)]
    public float duration = 0.1f;

    public float intensity = 1f;

    [Min(0f)]
    public float delay = 0f;


    [Header("Animation Settings")]
    public Color flashColor = Color.white;

}
