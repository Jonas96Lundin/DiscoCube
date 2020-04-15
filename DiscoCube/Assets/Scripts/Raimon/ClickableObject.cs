using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    private GameObject definedButton;
    [SerializeField]
    private ParticleSystem particleSystem;
    public UnityEvent OnClick = new UnityEvent();
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
        anim = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        particleSystem.Play();
        if (null != anim)
        {
            anim.Play("CubeAnimation");
        }
    }
    private void OnMouseExit()
    {
        particleSystem.Stop();
        if (null != anim)
        {
            anim.Play("CubeStill");
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
