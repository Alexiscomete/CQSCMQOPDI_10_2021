using UnityEngine;

public class UseCard : MonoBehaviour
{
    FollowCard lastCard = null;
    public FollowCard current;

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
