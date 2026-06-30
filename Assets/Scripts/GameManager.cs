using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //auto-property
    [field: SerializeField] public int WoodAmount { get; private set; }
    [field: SerializeField] public int MoneyAmount { get; private set; }
    [field: SerializeField] public int CurrentDay { get; private set; } = 1;
    [field: SerializeField] public int SeedlingAmount { get; private set; }
    [field: SerializeField] public int BaseAxePower { get; private set; }
    [field: SerializeField] public int CurrentAxePower { get; private set; }
    [field: SerializeField] public bool IsShopOpen { get; private set; }

    public static event Action OnStateChanged;
    public static event Action OnNextDay;

    [SerializeField] private int treesOnScene;

    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ChangeWood(int delta)
    {
        if (delta <= 0) return;
        WoodAmount += delta;
        OnStateChanged?.Invoke();
    }

    public void ChangeSeedlings(int delta)
    {
        if (delta <= 0) return;
        SeedlingAmount += delta;
        OnStateChanged?.Invoke();
    }

    public void ChangeMoney(int delta)
    {
        if (delta <= 0) return;
        MoneyAmount += delta;
        OnStateChanged?.Invoke();
    }

    public void ChangeAxePower(int delta)
    {
        CurrentAxePower += delta;
        if (CurrentAxePower < BaseAxePower)
            CurrentAxePower = BaseAxePower;
        OnStateChanged?.Invoke();
    }

    public bool TrySpendWood(int amount)
    {
        if ((WoodAmount < amount) || (amount <= 0)) return false;
        WoodAmount -= amount;
        OnStateChanged?.Invoke();
        return true;
    }

    public bool TrySpendMoney(int amount)
    {
        if ((MoneyAmount < amount) || (amount <= 0)) return false;
        MoneyAmount -= amount;
        OnStateChanged?.Invoke();
        return true;
    }
    public void ChangeShop()
    {
        IsShopOpen = !IsShopOpen;
        Debug.Log("Shop Panel Changed");
        OnStateChanged?.Invoke();
    }
    public void NextDay()
    {
        CurrentDay++;
        ChangeShop();
        OnStateChanged?.Invoke();
        OnNextDay?.Invoke();
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