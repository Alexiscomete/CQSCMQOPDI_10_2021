using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public static Deck[] decks = { null, null, null, null };
    public int deckNum;
    public List<FollowCard> fc = new List<FollowCard>();
    public Transform user;

    void Start()
    {
        decks[deckNum] = this;
    }

    void Update()
    {
        
    }

    public void AddCard(FollowCard fc)
    {
        fc.follow = null;
        this.fc.Add(fc);
    }

    public void SetPosCards()
    {
        if (deckNum == 0)
        {
            float currentx = 0;
            foreach (FollowCard r in fc)
            {
                r.target = transform.position + new Vector3(currentx, -1.3f, fc.Count - currentx*2);
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
        return Distance(user.position);
    }
}
