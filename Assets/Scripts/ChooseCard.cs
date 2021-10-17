using UnityEngine;

public class ChooseCard : MonoBehaviour
{
    private static string[] colors = {"Blue", "Yellow", "Red", "Green"};
    private static string[] values = {"0", "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8", "9", "9", "Draw", "Reverse", "Skip"};

    public SpriteRenderer spriteR;

    //private static Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        //sprites = Resources.LoadAll<Sprite>("./cards/");
        System.Random ran = new System.Random();
        if (ran.Next(10)==3)
        {

        }
        else
        {
            string card = colors[ran.Next(colors.Length)] + "_" + values[ran.Next(values.Length)];
            SetSpriteByName(card);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpriteByName(string name)
    {
        Debug.Log(name);
        spriteR.sprite = Resources.Load<Sprite>(name);
        Resources.UnloadUnusedAssets();
    }
}
