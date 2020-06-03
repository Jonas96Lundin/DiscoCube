using UnityEngine;

public class OnTriggerSender : MonoBehaviour
{
    private ColorSwitch parent;
    Renderer renderer;

    void Start()
    {
        parent = GetComponentInParent<ColorSwitch>();
        renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.ToLower() == parent.triggerColor.ToString())
        {
            if (parent.currentlyOnTrigger)
            {
                return;
            }

            //Change bool from false/true into true/false
            parent.triggerActivated = !parent.triggerActivated;
            if (parent.triggerActivated == true)
            {
                AudioManager.instance.Play("Switch");
                //Sett color to green on activation
                renderer.material.SetColor("_Color", new Color(0.1f,0.8f,0.1f));
                parent.SendUpdateRequest();
            }
            else if (parent.triggerActivated == false)
            {
                //Sett color to red on deactivation
                renderer.material.SetColor("_Color", Color.red);
                parent.SendUpdateRequest();
            }

            parent.currentlyOnTrigger = true;
        }
    }

    public void OnTriggerExit()
    {
        parent.currentlyOnTrigger = false;
    }
}
