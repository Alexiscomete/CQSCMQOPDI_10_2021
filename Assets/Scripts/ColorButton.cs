using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public string color;
    public GameObject colors;

    public void Select()
    {
        UseCard.current.faceOfCard.color = color;
        switch (color)
        {
            case "r":
                UseCard.current.faceOfCard.spriteR.color = new Color();
                break;
        }
    }
}
