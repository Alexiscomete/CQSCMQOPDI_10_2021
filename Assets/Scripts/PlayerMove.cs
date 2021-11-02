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
        if (Turns.turn == 0)
        {
            if (ActionR.tasks[0] > -1)
            {
                if (ActionR.tasks[0] == 0)
                {
                    Turns.NextTurn();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && Distance(UseCard.pos.transform.position) < 1 && card != null && card.faceOfCard.CanPlay())
            {
                UseCard.pos.PlayCard(card);
                card = null;
            }
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

    float Distance(Vector2 vec)
    {
        return Mathf.Sqrt(Mathf.Pow(vec.x - transform.position.x, 2) + Mathf.Pow(vec.y - transform.position.y, 2));
    }
}
