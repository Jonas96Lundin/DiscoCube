using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    private static bool isCounting = true;

    private float timer = 0f;

    [SerializeField]
    Text timerCounterText;

    void Start()
    {
        IsCounting = true;
    }
    public static bool IsCounting
    {
        set { isCounting = value; }
        get { return isCounting; }
    }

    public float Timer
    {
        get { return timer; }
    }
    
    
    void Update()
    {
        if (isCounting == true)
        {
            timer += 1 * Time.deltaTime;
            timerCounterText.text = timer.ToString("0");
        }
        
    }
}
