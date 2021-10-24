using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public static Deck[] decks = { null, null, null, null };
    public int deckNum;
    public List<FollowCard> fc = new List<FollowCard>();

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
        foreach (FollowCard r in fc)
        {
            r.follow = gameObject;
            if (deckNum == 0)
            {
                r.SetFace(true);
            }
        }
    }
}
