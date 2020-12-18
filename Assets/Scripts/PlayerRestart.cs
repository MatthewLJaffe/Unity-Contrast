using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : ResetLevel
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }
}
