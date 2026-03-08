using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodAmount;
    [SerializeField] private TextMeshProUGUI moneyAmount;
    [SerializeField] private TextMeshProUGUI currentDay;
    private const string WoodTextUI = "Wood: ";
    private const string MoneyTextUI = "$$$: ";
    private const string DayTextUI = "Day: ";

    private void Start()
    {
        GameManager.OnStateChanged += UpdateGUI;
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        woodAmount.text = WoodTextUI + GameManager.Instance.WoodAmount;
        moneyAmount.text = MoneyTextUI + GameManager.Instance.MoneyAmount;
        currentDay.text = DayTextUI + GameManager.Instance.CurrentDay;
    }

    private void OnDestroy()
    {
        GameManager.OnStateChanged -= UpdateGUI;
    }
}
