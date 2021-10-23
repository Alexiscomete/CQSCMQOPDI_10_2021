using UnityEngine;

public class ActionR : MonoBehaviour
{
    public int reeNum;
    public GameObject baseR;
    public float force;
    public static int[] tasks = {7, 7, 7, 7};
    public static int right = -1, left = -1;
    public GameObject deckR, deckL;

    // Update is called once per frame
    void Update()
    {
        if (tasks[reeNum] > 0)
        {
            if (reeNum < 2)
            {
                if (left == -1)
                {
                    left = reeNum;
                }
                else if (reeNum == left)
                {

                }
                else
                {
                    GoToBase();
                }
            }
            else
            {

            }
        }
        else
        {
            GoToBase();
        }
    }

    void GoToBase()
    {
        transform.Translate((baseR.transform.position - transform.position).normalized * force * Time.fixedDeltaTime);
    }
}
