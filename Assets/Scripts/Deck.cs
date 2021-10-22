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
}
