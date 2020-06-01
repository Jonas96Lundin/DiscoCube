using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject leftGate, rightGate;

    [Header("Movement distance")]
    [SerializeField]
    Vector3 dir;

    private bool triggerActivated = false, currentlyOnTrigger = false;
    Renderer renderer;

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
            }
            else if (triggerActivated == false)
            {   
                //Move gates to the side
                leftGate.transform.Translate(dir);
                rightGate.transform.Translate(-dir);
                //Sett color to red on deactivation
                renderer.material.SetColor("_Color", Color.red);
            }

            currentlyOnTrigger = true;
        }
        
    }

    public void OnTriggerExit()
    {
        currentlyOnTrigger = false;
    }

}
