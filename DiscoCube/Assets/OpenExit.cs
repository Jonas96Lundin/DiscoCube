using UnityEngine;

public class OpenExit : MonoBehaviour
{
	private bool hasMoved;
	[SerializeField]
	SwitchController switchcontroller;

	[SerializeField]
	GameObject[] objectsToMove;

	void Update()
    {
        if (hasMoved == true)
        {
			return;
        }
		if (switchcontroller.allSwitchesTrue)
		{
            for (int i = 0; i < objectsToMove.Length; i++)
            {
				objectsToMove[i].transform.Translate(new Vector3(0, -5, 0));
            }
			hasMoved = true;
		}
	}
    
}
