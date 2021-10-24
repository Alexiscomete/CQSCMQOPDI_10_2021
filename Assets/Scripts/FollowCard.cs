using UnityEngine;

public class FollowCard : MonoBehaviour
{
    public static FollowCard lastCardRight = null, lastCardLeft = null;

    public GameObject follow = null;
    public float timeOffSet;
    public Vector3 velocity;
    public bool face = false;
    public SpriteRenderer spFront;
    public SpriteRenderer spBack;

    void Start()
    {
        SetFace(false);
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