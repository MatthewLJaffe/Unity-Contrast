using System;
using UnityEngine;

public class ChangeDimension : MonoBehaviour
{
    [SerializeField] public bool darken;
    public static Action<bool> OnDimensionChange = delegate { };
    public Animator animator;
    private void Start() {
        OnDimensionChange(darken);
        darken = !darken;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            OnDimensionChange(darken);
            darken = !darken;
            GameObject[] elements = GameObject.FindGameObjectsWithTag("DimensionalElement");
            if(darken == false){
                for(int i = 0; i < elements.Length; i++){
                    // Layer 9: Light
                    // Layer 10: Dark
                    // Layer 13: Invisible
                    if(elements[i].layer == 9){
                        elements[i].layer = 13;
                    }
                    else if(elements[i].layer == 13){
                        elements[i].layer = 10;
                    }
                }
            }
            else{
                for(int i = 0; i < elements.Length; i++){
                    // Layer 9: Light
                    // Layer 10: Dark
                    // Layer 13: Invisible
                    if(elements[i].layer == 10){
                        elements[i].layer = 13;
                    }
                    else if(elements[i].layer == 13){
                        elements[i].layer = 9;
                    }
                }
            }

            animator.SetBool("Dark", darken);
        }

    }
}
