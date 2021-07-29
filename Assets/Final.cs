using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Final : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject button;
    private Color alpha;

    private void OnEnable()
    {
        image.gameObject.SetActive(true);
        alpha = new Color(1, 1, 1, 0.5f);
        FadeIn();

    }

    private void FadeIn()
    {
        image.DOColor(alpha, 1f).OnComplete(()=> button.SetActive(true));
        alpha = new Color(1, 1, 1, 0);
    }
    public void FadeOut()
    {
        button.SetActive(false);
        image.DOColor(alpha, 0.5f);
    }
}
