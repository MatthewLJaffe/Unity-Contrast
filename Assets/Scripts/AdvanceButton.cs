using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceButton : MonoBehaviour
{
    [SerializeField] private float buttonSink;
    private float pressedY;
    [SerializeField] private float resetDelay;
    private bool reset;

    private void Awake() {
        pressedY = transform.position.y - buttonSink;
        reset = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        transform.position = new Vector2(transform.position.x, pressedY);
        if(!reset)
            StartCoroutine(StartAdvance());
        reset = true;
    }

    private IEnumerator StartAdvance() {
        yield return new WaitForSeconds(resetDelay);
        if (GameHandler.Instance != null)
            GameHandler.Instance.LoadNextScene();
    }
}
