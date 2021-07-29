using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{

    private Color alpha;
    [SerializeField] private Text text;

    private void Start()
    {
        alpha = new Color(1, 1, 1, 1);
        FadeIn();
    }

    private void FadeIn()
    {
        text.DOColor(alpha, 0.5f);
    }

}
