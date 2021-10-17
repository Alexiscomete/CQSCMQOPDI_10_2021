using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontOrBack : MonoBehaviour
{

    public bool face = false;
    public SpriteRenderer spFront;
    public SpriteRenderer spBack;

    void Start()
    {
        SetFace(false);
    }

    public void SetFace(bool face)
    {
        this.face = face;
        if (face)
        {
            spFront.color = new Color(255, 255, 255, 255);
            spBack.color = new Color(255, 255, 255, 0);
        }
        else
        {
            spFront.color = new Color(255, 255, 255, 0);
            spBack.color = new Color(255, 255, 255, 255);
        }
    }

    public void MoveTo(GameObject game)
    {

    }
}
