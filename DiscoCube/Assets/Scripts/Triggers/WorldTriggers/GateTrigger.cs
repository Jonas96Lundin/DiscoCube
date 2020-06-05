using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    //Creator Raimon
    [SerializeField]
    GameObject leftGate, rightGate;

    [Header("Movement distance")]
    [SerializeField]
    Vector3 dir;

    private bool triggerActivated = false, currentlyOnTrigger = false;
    private Renderer renderer;
    public Renderer capsule;

    void Start()
    {
        renderer = this.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerSide")
        {
            if (currentlyOnTrigger)
            {
                return;
            }

            //Change bool from false/true into true/false
            triggerActivated = !triggerActivated;
            if (triggerActivated == true)
            {
                //Move gates to the side
                leftGate.transform.Translate(-dir);
                rightGate.transform.Translate(dir);
                //Sett color to green on activation
                renderer.material.SetColor("_Color", Color.green);
                capsule.enabled = false;
            }
            else if (triggerActivated == false)
            {   
                //Move gates to the side
                leftGate.transform.Translate(dir);
                rightGate.transform.Translate(-dir);
                //Sett color to red on deactivation
                renderer.material.SetColor("_Color", Color.red);
                capsule.enabled = true;
            }

            currentlyOnTrigger = true;
        }
        
    }

    public void OnTriggerExit()
    {
        currentlyOnTrigger = false;
    }

}
