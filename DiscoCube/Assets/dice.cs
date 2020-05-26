using UnityEngine;
using UnityEngine.UI;

public class dice : MonoBehaviour
{
    public Text score;

    void RollDice()
    {
        int number = Random.Range(1,7);
        score.text = number.ToString();
    }
}
