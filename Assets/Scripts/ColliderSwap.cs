using System.Net.NetworkInformation;
using UnityEngine;

public class ColliderSwap : MonoBehaviour, IDimensionInteraction
{
    [SerializeField] private bool isDark;
    private BoxCollider2D boxCollider;
    private void Awake() {
        ChangeDimension.OnDimensionChange += DimensionInteraction;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnDestroy() {
        ChangeDimension.OnDimensionChange -= DimensionInteraction;
    }

    //toggles collider on or off based on OnDimensionChange event
    public void DimensionInteraction(bool darken) {
        boxCollider.enabled = darken != isDark;
        //Debug.Log(boxCollider.enabled);
    }
}
