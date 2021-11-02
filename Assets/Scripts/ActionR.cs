using UnityEngine;

public class ActionR : MonoBehaviour
{
    public int reeNum;
    public GameObject baseR;
    public float force;
    public static int[] tasks = {7, 7, 7, 7};
    public static int right = -1, left = -1;
    public GameObject deckR, deckL;
    FollowCard card = null;
    public GameObject cardModel;
    bool getCard = false, pos = false;
    static int u = 4;

    // Update is called once per frame
    void Update()
    {
        if (getCard)
        {
            if (pos)
            {
                card = FollowCard.lastCardLeft;
                FollowCard.lastCardLeft = null;
                card.follow = gameObject;
                left = -1;
                getCard = false;
            }
            else
            {
                card = FollowCard.lastCardRight;
                FollowCard.lastCardRight = null;
                card.follow = gameObject;
                right = -1;
                getCard = false;
            }
        }
        else if (card == null)
        {
            if (tasks[reeNum] > 0)
            {
                if (reeNum < 2)
                {
                    if (left == -1)
                    {
                        left = reeNum;
                        GoTo(deckL.transform);
                    }
                    else if (reeNum == left)
                    {
                        GoTo(deckL.transform);
                        if (Distance(deckL.transform.position) < 0.5)
                        {
                            Instantiate(cardModel, deckL.transform.position, Quaternion.identity);
                            getCard = true;
                            pos = true;
                        }
                    }
                    else
                    {
                        GoToBase();
                    }
                }
                else
                {
                    if (right == -1)
                    {
                        right = reeNum;
                        GoTo(deckR.transform);
                    }
                    else if (reeNum == right)
                    {
                        GoTo(deckR.transform);
                        if (Distance(deckR.transform.position) < 0.5)
                        {
                            Instantiate(cardModel, deckR.transform.position, Quaternion.identity);
                            getCard = true;
                            pos = false;
                        }
                    }
                    else
                    {
                        GoToBase();
                    }
                }
            }
            else
            {
                GoToBase();
            }
        }
        else
        {
            GoTo(Deck.decks[reeNum].transform);
            if (Distance(Deck.decks[reeNum].transform.position) < 0.7)
            {
                Deck.decks[reeNum].AddCard(card);
                card = null;
                tasks[reeNum]--;
                if (tasks[reeNum] == 0)
                {
                    Deck.decks[reeNum].SetPosCards();
                    Deck.decks[reeNum].pos = false;
                    if (u > 0)
                    {
                        u--;
                        tasks[reeNum] = -1;
                        if (u == 0)
                        {
                            Turns.NextTurn();
                        }
                    }
                }
            }
        }
    }

    void GoToBase()
    {
        if (Distance(baseR.transform.position) > 0.2)
        {
            transform.Translate((baseR.transform.position - transform.position).normalized * force * Time.fixedDeltaTime);
        }
    }

    void GoTo(Transform tra)
    {
        transform.Translate((tra.position - transform.position).normalized * force * Time.fixedDeltaTime);
    }

    float Distance(Vector2 vec)
    {
        return Mathf.Sqrt(Mathf.Pow(vec.x - transform.position.x, 2) + Mathf.Pow(vec.y - transform.position.y, 2));
    }
}
