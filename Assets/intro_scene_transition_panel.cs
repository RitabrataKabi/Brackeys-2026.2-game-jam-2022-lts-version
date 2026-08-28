using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intro_scene_transition_panel : MonoBehaviour
{
    // [SerializeField] private Image _image;
    // [SerializeField] private float timeToCompleteTransition = 1000f; //in milliseconds 

    // public void DoTransition()
    // {

    // }

    // IEnumerator TransitionFlow()
    // {
    //     float tickSpeed = 0.01f; //100 ms loop once
    //     float currentAlphaValue = 0;
    //     float maxAlphaValue = 1;

    //     float rateOfChange = (maxAlphaValue - currentAlphaValue) / timeToCompleteTransition;

    //     while (currentAlphaValue < maxAlphaValue)
    //     {
    //         _image.color.a = 1f;
    //     }
    // }

    [SerializeField] private Image loadingScreenPanel;

    [SerializeField, Tooltip("In milliseconds")] public float duration = 16f;

    private void Start()
    {
        if (duration <= 1f)
        {
            duration = 100f;
        }
    }

    public void Initiate()
    {
        if (loadingScreenPanel != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        loadingScreenPanel.color += new Color(0, 0, 0, 1f);
        yield break;
    }
}
