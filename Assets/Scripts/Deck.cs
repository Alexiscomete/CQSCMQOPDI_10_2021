using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public static Deck[] decks = { null, null, null, null };
    public int deckNum;
    public List<FollowCard> fc = new List<FollowCard>();
    public PlayerMove user;
    public bool pos = false;
    public GameObject entity;

    void Start()
    {
        decks[deckNum] = this;
    }

    void Update()
    {
        if (deckNum == 0)
        {
            if (!pos && UserDistance() < 2)
            {
                pos = true;
                SetPosCards(-1f);
            }
            else if (pos && UserDistance() > 2)
            {
                pos = false;
                SetPosCards(-1.3f);
            }
        }
    }

    public void AddCard(FollowCard fc)
    {
        fc.follow = null;
        this.fc.Add(fc);
    }

    public void SetPosCards()
    {
        SetPosCards(-1.3f);
    }

    public void SetPosCards(float y)
    {
        if (deckNum == 0)
        {
            float currentx = 0;
            foreach (FollowCard r in fc)
            {
                r.target = transform.position + new Vector3(currentx, y, fc.Count - currentx * 2);
                r.asTarget = true;
                r.SetFace(true);
                currentx += 0.5f;
                if (r.faceOfCard.CanPlay())
                {
                    r.collider.enabled = true;
                }
                else
                {
                    r.collider.enabled = false;
                }
            }
        }
        else
        {
            foreach (FollowCard r in fc)
            {
                r.follow = gameObject;
            }
        }
    }

    float Distance(Vector2 vec)
    {
        return Mathf.Sqrt(Mathf.Pow(vec.x - transform.position.x, 2) + Mathf.Pow(vec.y - transform.position.y, 2));
    }

    public float UserDistance()
    {
        return Distance(user.transform.position);
    }
}
