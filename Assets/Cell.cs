using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cellSprite;
    [SerializeField] private string identifier;
    private CardBundleData cardData;
    private Level level;
    [SerializeField] private List<UnityEvent> effects = new List<UnityEvent>();

    private void Start()
    {
        cellSprite.sprite = null;
        level = FindObjectOfType<Level>();
        cardData = level.CurrentCardKit;
        Filling();
        TieToLevel();
    }
    private void Filling()
    {
        int randomCard = Random.Range(0, cardData.Cards.Length);
        for (int i = 0; i < cardData.Cards.Length; i++)
        {
            if (randomCard == i)
            {
                cellSprite.sprite = cardData.Cards[i].Sprite;
                identifier = cardData.Cards[i].Identifier;
                ReplayPresence();
                if (!ReplayPresence())
                {
                    level.UseLevelCard(cardData.Cards[i]);
                }
                else
                {
                    Filling();
                    return;
                }
            }
        }
        for (int i = 0; i < cardData.Cards.Length; i++)
        {
            if (level.Answer == false)
            {
                if (cardData.Cards[i].Identifier == level.Target)
                {
                    cellSprite.sprite = cardData.Cards[i].Sprite;
                    identifier = cardData.Cards[i].Identifier;
                    level.AnswerDone();
                    level.UseLevelCard(cardData.Cards[i]);
                    Debug.Log("answerDone");
                }
            }
        }
        
    }

    private bool ReplayPresence()
    {
        for (int i = 0; i < level.UsedLevelCard.Count; i++)
        {
            if (identifier == level.UsedLevelCard[i].Identifier)
            {
                return true;
            }
        }
        return false;
    }
    private void TieToLevel()
    {
        level.AddCell(this);
    }

    private void OnMouseDown()
    {
        
        if (identifier == level.Target)
        {
            Debug.Log("Win");
            effects[0].Invoke();
            level.CompleteLevel();
        }
        else
        {
            effects[1].Invoke();
            Debug.Log("Lose");
        }
    }

    private void OnDestroy()
    {
        cellSprite.sprite = null;
    }
}
