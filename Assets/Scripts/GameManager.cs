using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //auto-property
    [field: SerializeField] public int WoodAmount { get; private set; }
    [field: SerializeField] public int MoneyAmount { get; private set; }
    [field: SerializeField] public int CurrentDay { get; private set; } = 1;

    public static event Action OnStateChanged;

    [SerializeField] private int treesOnScene;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddWood(int amount)
    {
        WoodAmount += amount;
        OnStateChanged?.Invoke();
    }

    //TODO: metoda ta daje $$ z drzewa ale jeszcze będzie trzeba sprzedawać drewno za $$$
    public void AddMoney(int amount)
    {
        MoneyAmount += amount;
        OnStateChanged?.Invoke();
    }

    public void NextDay()
    {
        CurrentDay++;
        OnStateChanged?.Invoke();
    }

    public void RegisterTree()
    {
        treesOnScene++;
    }
    public void UnregisterTree()
    {
        treesOnScene--;
        
        if (treesOnScene <= 0)
        {
            Debug.Log("Wszystkie drzewa ścięte!");
        }
    }
}