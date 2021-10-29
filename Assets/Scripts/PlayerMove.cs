using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool up = false, down = false, right = false, left = false;
    public Transform rb;
    public float force;
    public FollowCard card;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            down = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
        }
    }

    private void FixedUpdate()
    {
        if (up)
        {
            rb.Translate(new Vector2(0f, force) * Time.fixedDeltaTime);
            up = false;
        }
        if (down)
        {
            rb.Translate(new Vector2(0f, -force) * Time.fixedDeltaTime);
            down = false;
        }
        if (right)
        {
            rb.Translate(new Vector2(force, 0f) * Time.fixedDeltaTime);
            right = false;
        }
        if (left)
        {
            rb.Translate(new Vector2(-force, 0f) * Time.fixedDeltaTime);
            left = false;
        }
    }
}
