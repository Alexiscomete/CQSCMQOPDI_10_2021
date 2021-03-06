using UnityEngine;
using System;

public class FollowCard : MonoBehaviour
{
    public static FollowCard lastCardRight = null, lastCardLeft = null;

    public GameObject follow = null;
    public float timeOffSet;
    public Vector3 velocity;
    public bool face;
    public SpriteRenderer spFront;
    public SpriteRenderer spBack;
    public ChooseCard faceOfCard;
    public BoxCollider2D collider;
    public bool asTarget = false;
    public Vector3 target;

    void Start()
    {
        SetFace(face);
        if (transform.position.x > 0)
        {
            lastCardRight = this;
        }
        else
        {
            lastCardLeft = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (follow != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, follow.transform.position, ref velocity, timeOffSet);
        }
        else if (asTarget)
        {
            if (Distance(target) > 0.03)
            {
                transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.5f);
            }
            else
            {
                asTarget = false;
            }
        }
        
    }

    public void SetFace(bool face)
    {
        this.face = face;
        if (face)
        {
            spFront.color = new Color(255, 255, 255, 255);
            spBack.color = new Color(255, 255, 255, 0);
        }
        else
        {
            spFront.color = new Color(255, 255, 255, 0);
            spBack.color = new Color(255, 255, 255, 255);
        }
    }

    float Distance(Vector2 vec)
    {
        return Mathf.Sqrt(Mathf.Pow(vec.x - transform.position.x, 2) + Mathf.Pow(vec.y - transform.position.y, 2));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Deck de = Deck.decks[0];
            if (de.UserDistance() < 2)
            {
                follow = de.entity;
                if (de.user.card != null)
                {
                    de.user.card.follow = null;
                    de.AddCard(de.user.card);
                }
                de.user.card = this;
                de.fc.Remove(this);
                de.SetPosCards(-1f);
            }
        }
    }

    public void SetCard(Deck de)
    {
        follow = de.entity;
        de.fc.Remove(this);
    }
}
