using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private List<Card> _usedCard = new List<Card>();
    public List<Card> UsedCard => _usedCard;

    [SerializeField] private Final final;
    int currentLevel;
    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel >= levels.Count)
        {
            EndGame();
        }
        for (int i = 0; i < levels.Count; i++)
        {
            if (i == currentLevel)
            {
                levels[i].gameObject.SetActive(true);
            }
            else
            {
                levels[i].gameObject.SetActive(false);
            }
            
            
        }
    }
    private void EndGame()
    {
        final.enabled = true;
    }

    public void Restart()
    {
        currentLevel = -1;
        for (int i = 0; i < _usedCard.Count; i++)
        {
            _usedCard.RemoveAt(i);
        }
        NextLevel();
        final.enabled = false;
    }

    public void UseCard(Card card)
    {
        _usedCard.Add(card);
    }
}
