using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystemToUse;
    [SerializeField]
    private GameObject canvasText;
    [SerializeField]
    private UnityEvent OnClick = new UnityEvent();

    private void OnMouseEnter()
    {
        canvasText.SetActive(true);
        foreach (Transform transform in transform.parent)
        {
            if (transform.tag == this.tag)
            {
                ClickableObject temp = transform.GetComponent<ClickableObject>();
                temp.particleSystemToUse.Play();
            }
            
        }
    }
    private void OnMouseExit()
    {
        canvasText.SetActive(false);
        foreach (Transform transform in transform.parent)
        {
            ClickableObject temp = transform.GetComponent<ClickableObject>();
            temp.particleSystemToUse.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                Debug.Log("Hit cube.");
                OnClick.Invoke();
            }
        }
    }
}
