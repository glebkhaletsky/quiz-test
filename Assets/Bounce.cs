using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bounce : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector3.zero;
        Invoke(nameof(BounceEffect), 0.3f);
    }
    private void BounceEffect()
    {
        transform.DOScale(Vector3.one * 1.2f, 0.3f).OnComplete(() =>
         transform.DOScale(Vector3.one * 0.95f, 0.3f)).OnComplete(() =>
          transform.DOScale(Vector3.one, 0.3f));
    }
}
