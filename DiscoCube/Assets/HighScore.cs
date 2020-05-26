using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    Text stepScore, timeScore;
    [SerializeField]
    GameManager gm;


    private void OnEnable()
    {
        StepCounter sc = gm.GetComponent<StepCounter>();
        CountUpTimer ct = gm.GetComponent<CountUpTimer>();
        SetStepHighScore(sc);
        SetTimeHighScore(ct);
    }
    void Start()
    {
        
    }


    public void Remove()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SetStepHighScore(StepCounter stepCounter)
    {
        int steps = stepCounter.stepCounter;
       

        if (steps < PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Steps", 99))
        {
            Debug.Log("Stepcounter is: " + stepCounter.stepCounter + "(Inside if)");
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Steps", steps);
            stepScore.text = "Steps: " + steps.ToString();
        }
        else
        {
            Debug.Log("Stepcounter is: " + stepCounter.stepCounter + "(outside if)");
            stepScore.text = "Steps: " + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Steps").ToString();
        }
    }

    public void SetTimeHighScore(CountUpTimer timer)
    {
        float time = timer.Timer + 0.001f;

        if (time < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time", 999))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Time", time);
            timeScore.text = "Time: " + time.ToString("0.000");
        }
        else
        {
            timeScore.text = "Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time").ToString("0.000");
        }
    }
}
