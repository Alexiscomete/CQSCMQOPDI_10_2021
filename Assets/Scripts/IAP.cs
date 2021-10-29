using UnityEngine;

public class IAP : MonoBehaviour
{
    public int num;
    public FollowCard fc;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Turns.turn != num && Turns.turn != (num + 3)%4)
        {

        }
        else
        {
            if (fc != null)
            {

            }
            else
            {
                if (!GoToBase())
                {

                }
            }
        }
    }

    bool GoToBase()
    {

        if (Distance(Deck.decks[num].transform.position) > 0.5)
        {
            transform.Translate((Deck.decks[num].transform.position - transform.position).normalized * force * Time.fixedDeltaTime);
            return true;
        }
        return false;
    }

    void GoTo(Transform tra)
    {
        transform.Translate((tra.position - transform.position).normalized * force * Time.fixedDeltaTime);
    }

    float Distance(Vector2 vec)
    {
        return Mathf.Sqrt(Mathf.Pow(vec.x - transform.position.x, 2) + Mathf.Pow(vec.y - transform.position.y, 2));
    }
}
