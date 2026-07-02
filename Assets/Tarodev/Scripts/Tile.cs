using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _spriteRendererColor;
    [SerializeField] private GameObject _spriteRendererHighlight;

    private void Awake()
    {
        if (_spriteRendererColor == null) _spriteRendererColor = GetComponent<SpriteRenderer>();
    }

    public void Init(bool isOffset)
    {
        _spriteRendererColor.color = isOffset ? _offsetColor : _baseColor;
    }

    private void OnMouseEnter()
    {
        _spriteRendererHighlight.SetActive(true);
    }

   

    private void OnMouseExit()
    {
        _spriteRendererHighlight.SetActive(false);
    }
}