using UnityEngine;

public class Turns : MonoBehaviour
{
    public static int turn = -1;

    public static void NextTurn()
    {
        turn = (turn + 1) % 4;
        Deck.decks[0].SetPosCards();
    }

    public static void AddCardToNext(int num)
    {
        if (ActionR.tasks[(turn + 1) % 4] == -1)
        {
            num++;
        }
        ActionR.tasks[(turn + 1) % 4] += num;
    }
}
