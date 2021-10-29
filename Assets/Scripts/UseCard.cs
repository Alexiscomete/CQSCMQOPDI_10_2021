using UnityEngine;

public class UseCard : MonoBehaviour
{
    public FollowCard lastCard = null;
    public static FollowCard current;
    public static UseCard pos;

    private void Start()
    {
        current = lastCard;
        lastCard = null;
        pos = this;
    }

    public void PlayCard(FollowCard follow)
    {
        follow.SetFace(true);
        if (lastCard != null)
        {
            Destroy(lastCard);
        }
        lastCard = current;
        lastCard.transform.Translate(0, 0, 100);
        current = follow;
        follow.follow = gameObject;
        if (follow.faceOfCard.type == "Wild")
        {
            ColorButton.co.SetActive(true);
            if (follow.faceOfCard.value == "Draw")
            {
                Turns.AddCardToNext(4);
            }
        }
        else if (follow.faceOfCard.value == "Draw")
        {
            Turns.AddCardToNext(2);
            Turns.NextTurn();
            Turns.NextTurn();
        }
        else
        {
            Turns.NextTurn();
        }
    }
}
