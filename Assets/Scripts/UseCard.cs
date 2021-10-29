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
        current = follow;
        follow.follow = gameObject;
    }
}
