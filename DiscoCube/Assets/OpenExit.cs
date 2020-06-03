using UnityEngine;

public class OpenExit : MonoBehaviour
{
	private bool hasMoved;
	[SerializeField]
	SwitchController sc;

	[SerializeField]
	GameObject[] objectsToMove;

	void Update()
    {
        if (hasMoved == true)
        {
			return;
        }
		if (sc.allSwitchesTrue)
		{
            for (int i = 0; i < objectsToMove.Length; i++)
            {
				objectsToMove[i].transform.Translate(new Vector3(0, -5, 0));
            }
			hasMoved = true;
		}
	}
    
}
