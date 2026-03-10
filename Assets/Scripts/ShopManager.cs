using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int baseSeedlingCost = 2;
    [SerializeField] private int baseAxeUpgradeCost = 10;
    [SerializeField] private int baseSellingPriceWood = 1;

    public void OnSellWoodButtonClicked(int amount)
    {
        if (!GameManager.Instance.TrySpendWood(amount)) return;

        GameManager.Instance.ChangeMoney(amount * baseSellingPriceWood);
    }

    public void
        OnBuySeedlingButtonClicked(int seedlingsAmount) //TODO w przyszłości ilość zakupionych dostoswać do przycisku
    {
        int totalCost = seedlingsAmount * baseSeedlingCost;
        if (!GameManager.Instance.TrySpendMoney(totalCost)) return;

        GameManager.Instance.ChangeSeedlings(seedlingsAmount);
    }

    public void OnBuyAxeUpgradeButtonClicked(int amount)
    {
        if (!GameManager.Instance.TrySpendMoney(baseAxeUpgradeCost)) return;

        GameManager.Instance.ChangeAxePower(amount);
    }
}