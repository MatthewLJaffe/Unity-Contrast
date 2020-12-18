using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BackgroundSwap : MonoBehaviour, IDimensionInteraction
{
    [SerializeField] protected Sprite darkModeSprite;
    [SerializeField] protected Sprite lightModeSprite;

    protected SpriteRenderer spriteRenderer;

    protected void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeDimension.OnDimensionChange += DimensionInteraction;
    }

    protected void OnDestroy() {
        ChangeDimension.OnDimensionChange -= DimensionInteraction;
    }

    public virtual void DimensionInteraction(bool darken)
    {
        if (darken)
            spriteRenderer.sprite = darkModeSprite;
        else
            spriteRenderer.sprite = lightModeSprite;
    }
}
