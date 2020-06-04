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
        StepCounter stepCounter = gm.GetComponent<StepCounter>();
        CountUpTimer countUpTimer = gm.GetComponent<CountUpTimer>();
        CountdownTimer countdownTimer = gm.GetComponent<CountdownTimer>();
        if (countUpTimer == null)
        {
            SetTimeHighScore(countdownTimer);
        }
        else
        {
            SetTimeHighScore(countUpTimer);
        }
        SetStepHighScore(stepCounter);
    }

    public void SetStepHighScore(StepCounter stepCounter)
    {
        int steps = stepCounter.stepCounter;
       

        if (steps < PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Steps", 9999))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Steps", steps);
            stepScore.text = "Steps: " + steps.ToString();
        }
        else
        {
            stepScore.text = "Steps: " + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Steps").ToString();
        }
    }

    public void SetTimeHighScore(CountUpTimer timer)
    {
        float time = timer.Timer + 0.001f;

        if (time < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time", 9999))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Time", time);
            timeScore.text = "Time: " + time.ToString("0.000");
        }
        else
        {
            timeScore.text = "Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time").ToString("0.000");
        }
    }

    public void SetTimeHighScore(CountdownTimer timer)
    {
        float time = timer.Timer + 0.001f;

        if (time > PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time", 0))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Time", time);
            timeScore.text = "Time: " + time.ToString("0.000");
        }
        else
        {
            timeScore.text = "Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time").ToString("0.000");
        }
    }

    //For dev
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
