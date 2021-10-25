using UnityEngine;

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
    public BoxCollider2D minCollider, maxCollider;

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
}
