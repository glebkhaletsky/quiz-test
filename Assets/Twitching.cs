using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Twitching : MonoBehaviour
{
    void Start()
    {
        Twich();
    }

    private void Twich()
    {
        transform.DOShakePosition(0.5f, 1, 10, 10, false, true);
    }
    
}
