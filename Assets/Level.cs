using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private int numberCells;
    [SerializeField] private int rows;
    [SerializeField] private CardBundleData _currentCardKit;
    public CardBundleData CurrentCardKit=>_currentCardKit;

    [SerializeField] private List<Card> _usedLevelCard = new List<Card>();
    public List<Card> UsedLevelCard => _usedLevelCard;
    private string _target;
    public string Target => _target;
    private bool _answer;
    public bool Answer => _answer;
    [SerializeField] private Text task;
    private Grid grid;
    private Game currentGame;

    [SerializeField] private List<Cell> levelCells = new List<Cell>();

    [SerializeField] private UnityEvent appearanceEffect;
    private void OnEnable()
    {
        _answer = false;
        grid = FindObjectOfType<Grid>();
        currentGame = FindObjectOfType<Game>();
        FormulationTask();
        appearanceEffect.Invoke();
    }
    public void AddCell(Cell cell)
    {
        levelCells.Add(cell);
    }

    private void FormulationTask()
    {
        int randomCard = Random.Range(0, _currentCardKit.Cards.Length);
        for (int i = 0; i < _currentCardKit.Cards.Length; i++)
        {
            if(randomCard == i)
            {
                _target = _currentCardKit.Cards[i].Identifier;
                task.text = "Find: " + _currentCardKit.Cards[i].Identifier;
                ReplayPresence();
                if (!ReplayPresence())
                {
                    currentGame.UseCard(_currentCardKit.Cards[i]);
                }
                else
                {
                    FormulationTask();
                    return;
                }
                
            }
        }
        grid.GenerateGrid(numberCells, rows);
        
    }

    public void UseLevelCard(Card card)
    {
        _usedLevelCard.Add(card);
    }

    private bool ReplayPresence()
    {        
        for (int i = 0; i < currentGame.UsedCard.Count; i++)
        {
            if(_target == currentGame.UsedCard[i].Identifier)
            {
                return true;
            }
        }
        return false;
    }
    public void CompleteLevel()
    {
        for (int i = 0; i < levelCells.Count; i++)
        {
            Destroy(levelCells[i].gameObject);         
        }
        levelCells.Clear();
        currentGame.NextLevel();
    }

    public void AnswerDone()
    {
        _answer = true;
    }

}
