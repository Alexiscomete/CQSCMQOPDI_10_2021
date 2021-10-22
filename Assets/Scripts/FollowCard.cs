using UnityEngine;

public class FollowCard : MonoBehaviour
{
    public static FollowCard lastCardRight = null, lastCardLeft = null;

    public GameObject follow = null;
    public float timeOffSet;
    public Vector3 velocity;
    void Start()
    {
        if (transform.position.x == 1.61)
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
}
