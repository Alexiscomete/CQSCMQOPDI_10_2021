using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool up = false, down = false, right = false, left = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            up = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            down = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = true;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
