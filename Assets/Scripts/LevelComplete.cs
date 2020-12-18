using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public GameObject player;
    public string nextSceneName;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start() {
        collider = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() {
        if(collider.IsTouching(player.gameObject.GetComponent<Collider2D>())){
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
    }
}
