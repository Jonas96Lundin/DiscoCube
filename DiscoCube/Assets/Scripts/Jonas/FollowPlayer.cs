
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Update()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.Euler(15, 0, 0);
        Zoom();
    }
    private void Zoom()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            offset.z++;
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            offset.z--;
        }
    }
}
