using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class WinTrigger : MonoBehaviour
{
    private float winDelay;
    private bool win;
    private Vector3 endPos, endPosOrientation = new Vector3(0, -2.1f, 0);

    [Header("The color you want up for the player to win")]
    [SerializeField]
    ColorManager.CubeColors winColor;

    [SerializeField]
    GameObject nextLevelButton, completeLevelUI;

    void Start()
    {
        win = false;
        winDelay = 0f;
        //Assign the right wincolor to trigger
        winColor = ColorManager.SetWinColor(winColor);
    }
    void Update()
    {
        //Failsafe
        if (win == false)
        {
            return;
        }
        else
        {
            CountUpTimer.IsCounting = false;
            WinDelay();
        }
    }

    private void WinDelay()
    {
        //Add a delay for winning
        winDelay += 1 * Time.deltaTime;
        if (winDelay >= 2f)
        {
            ActivateWinUI();
            winDelay = 0;
        }
    }

    private void DenyMovement(Collider collider)
    {
        //Makes it impossible to move.
        Movement ms = collider.GetComponentInParent<Movement>();
        ms.DenyMovement = true;
    }

    public void ActivateWinUI()
    {
        completeLevelUI.SetActive(true);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.ToLower() == winColor.ToString())
        {
            endPos = collider.transform.position + endPosOrientation;
            //Clear selected object.
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new object
            EventSystem.current.SetSelectedGameObject(nextLevelButton);
            //Set win boolean to true so its possible to win
            win = true;
            //Deny movement and stop time from counting
            DenyMovement(collider);
            //Make the playerCube move down the hole
            collider.GetComponentInParent<Movement>().WinMovement(endPos);
        }
        else if (collider.gameObject.name.ToLower() != winColor.ToString() && win == false)
        {
            FindObjectOfType<WrongColorDialogue>().DialoguePopUp();
        }
    }
}
