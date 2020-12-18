using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTangibility : MonoBehaviour, IDimensionInteraction
{


    public enum Dimension {Light, Dark};
    public Dimension dimension;
    public Sprite tangible;
    public Sprite invisible;

    // Gameobject components
    private SpriteRenderer spriteRenderer;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        collider = this.gameObject.GetComponent<Collider2D>();
        DimensionInteraction(false);
        ChangeDimension.OnDimensionChange += DimensionInteraction;
    }

    public void OnDestroy() {
        ChangeDimension.OnDimensionChange -= DimensionInteraction;
    }

    public void DimensionInteraction(bool darken){
        if(dimension == Dimension.Light && darken == true) {
            spriteRenderer.sprite = invisible;
            collider.enabled = false;
        }
        else if(dimension == Dimension.Light && darken == false){
            spriteRenderer.sprite = tangible;
            collider.enabled = true;
        }
        else if(dimension == Dimension.Dark && darken == true){
            spriteRenderer.sprite = tangible;
            collider.enabled = true;
        } 
        else if(dimension == Dimension.Dark && darken == false){
            spriteRenderer.sprite = invisible;
            collider.enabled = false;
        }
    }
}
