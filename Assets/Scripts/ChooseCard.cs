using UnityEngine;

public class ChooseCard : MonoBehaviour
{
    private static string[] colors = {"Blue", "Yellow", "Red", "Green"};
    private static string[] values = {"0", "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8", "9", "9", "Draw", "Draw", "Reverse", "Reverse", "Skip", "Skip"};

    public SpriteRenderer spriteR;
    public string type = "", color = "", value = "";
    public bool firstCard;

    //private static Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        //sprites = Resources.LoadAll<Sprite>("./cards/");
        System.Random ran = new System.Random();
        if (firstCard)
        {
            type = "Normal";
            color = colors[ran.Next(colors.Length)];
            value = values[ran.Next(values.Length-3)];
            string card = color + "_" + value;
            SetSpriteByName(card);
        }
        else
        {
            int n = ran.Next(14);
            if (n == 3)
            {
                SetSpriteByName("Wild_Draw");
                type = "Wild";
                value = "Draw";
            }
            else if (n == 4 || n == 6)
            {
                SetSpriteByName("Wild");
                type = "Wild";
            }
            else
            {
                type = "Normal";
                color = colors[ran.Next(colors.Length)];
                value = values[ran.Next(values.Length)];
                string card = color + "_" + value;
                SetSpriteByName(card);
            }
        }
        
    }

    void SetSpriteByName(string name)
    {
        Debug.Log(name);
        spriteR.sprite = Resources.Load<Sprite>(name);
        Resources.UnloadUnusedAssets();
    }

    public bool CanPlay()
    {
        return UseCard.current.faceOfCard.color == color || type == "Wild" || UseCard.current.faceOfCard.value == value;
    }
}
