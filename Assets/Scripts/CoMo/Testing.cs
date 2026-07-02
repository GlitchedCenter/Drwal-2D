using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private int height;
    [SerializeField] private int width;

    private void Start()
    {
        width = 4;
        height = 2; 
        Grid grid = new Grid(width, height);
    }
}
