using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public string color;
    public GameObject colors;
    public static GameObject co;
    public static bool bo = false;

    private void Start()
    {
        co = colors;
        if (!bo)
        {
            bo = true;
            co.SetActive(false);
        }   
    }

    public void Select()
    {
        UseCard.current.faceOfCard.color = color;
        switch (color)
        {
            case "r":
                UseCard.current.faceOfCard.spriteR.color = new Color(255, 0, 0);
                break;
            case "g":
                UseCard.current.faceOfCard.spriteR.color = new Color(0, 255, 0);
                break;
            case "b":
                UseCard.current.faceOfCard.spriteR.color = new Color(0, 0, 255);
                break;
            case "y":
                UseCard.current.faceOfCard.spriteR.color = new Color(255, 255, 0);
                break;
        }
        Turns.NextTurn();
        colors.SetActive(false);
    }
}
