using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float currentHitPoints = 5;
    [SerializeField] private float maxHitPoints = 5;
    [SerializeField] private float woodAmount = 4;

    private void Start()
    {
        GameManager.Instance.RegisterTree();
    }

    public void TakeDamage(float damage)
    {
        currentHitPoints -= damage;

        if (currentHitPoints <= 0)
        {
            //TODO: dodać dźwięk ścinaniaa
            GameManager.Instance.ChangeWood((int)woodAmount);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.UnregisterTree();
    }
}
