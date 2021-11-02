using UnityEngine;

public class UseCard : MonoBehaviour
{
    public FollowCard lastCard;
    public static FollowCard current;
    public static UseCard pos;

    private void Awake()
    {
        pos = this;
    }

    private void Start()
    {
        current = lastCard;
        lastCard = null;
    }

    public void PlayCard(FollowCard follow)
    {
        follow.SetFace(true);
        follow.transform.Translate(0, 0, -100);
        if (lastCard != null)
        {
            Debug.Log("rrr");
            Destroy(lastCard.gameObject);
        }
        current.transform.Translate(0, 0, 100);
        lastCard = current;
        current = follow;
        follow.follow = gameObject;
        if (follow.faceOfCard.type == "Wild")
        {
            if (Turns.turn == 0)
            {
                ColorButton.co.SetActive(true);
            }
            if (follow.faceOfCard.value == "Draw")
            {
                Turns.AddCardToNext(4);
            }
        }
        else if (follow.faceOfCard.value == "Draw")
        {
            Turns.AddCardToNext(2);
            Turns.NextTurn();
        }
        else if (follow.faceOfCard.value == "Skip")
        {
            Turns.AddCardToNext(0);
            Turns.NextTurn();
        }
        else
        {
            Turns.NextTurn();
        }
    }
}
