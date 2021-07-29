using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewCardBundleData", menuName = "CardBundleData", order =10)]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private Card[] _cards;
    public Card[] Cards => _cards;
    
}
