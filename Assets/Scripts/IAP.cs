using UnityEngine;
using System.Collections.Generic;

public class IAP : MonoBehaviour
{
    public int num;
    public FollowCard fc;
    public float force;
    float lasty, lastx;
    Vector2 nextMove = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        lastx = UseCard.pos.transform.position.x;
        lasty = UseCard.pos.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionR.tasks[num] == 0 && Turns.turn == num)
        {
            Turns.NextTurn();
            ActionR.tasks[num] = -1;
        }
        else if (ActionR.tasks[num] == -1)
        {
            if (Turns.turn != num && Turns.turn != (num + 3) % 4)
            {
                if (Distance(new Vector2(lastx, lasty)) < 1)
                {
                    System.Random ran = new System.Random();
                    lastx = ran.Next(-500, 500) / 100 + UseCard.pos.transform.position.x;
                    lasty = ran.Next(-500, 500) / 100 + UseCard.pos.transform.position.y;
                }
                else
                {
                    GoTo(new Vector3(lastx, lasty));
                }
            }
            else if (Turns.turn == num)
            {
                if (fc != null)
                {
                    if (Distance(UseCard.pos.transform.position) < 0.5)
                    {
                        UseCard.pos.PlayCard(fc);
                        if (fc.faceOfCard.type == "Wild")
                        {
                            ColorButton.Select(Deck.decks[num].MaxColor());
                        }
                        fc = null;
                    }
                    else
                    {
                        GoTo(UseCard.pos.transform.position);
                    }
                }
                else
                {
                    if (!GoToBase())
                    {
                        List<FollowCard> cards = Deck.decks[num].fc;
                        foreach (FollowCard card in cards)
                        {
                            if (card.faceOfCard.CanPlay())
                            {
                                card.SetCard(Deck.decks[num]);
                                fc = card;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                GoToBase();
            }
        }
    }

    bool GoToBase()
    {

        if (Distance(Deck.decks[num].transform.position) > 0.5)
        {
            nextMove = (Deck.decks[num].transform.position - transform.position).normalized * force;
            return true;
        }
        return false;
    }

    void GoTo(Vector3 vec)
    {
        nextMove = (vec - transform.position).normalized * force;
    }

    float Distance(Vector2 vec)
    {
        return Mathf.Sqrt(Mathf.Pow(vec.x - transform.position.x, 2) + Mathf.Pow(vec.y - transform.position.y, 2));
    }

    private void FixedUpdate()
    {
        transform.Translate(nextMove * Time.fixedDeltaTime);
    }
}
