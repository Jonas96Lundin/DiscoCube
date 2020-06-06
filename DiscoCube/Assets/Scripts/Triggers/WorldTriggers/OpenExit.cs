using UnityEngine;

public class OpenExit : MonoBehaviour
{
	//Creator Raimon

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
				objectsToMove[i].transform.Translate(new Vector3(0, -6, 0));
				objectsToMove[i].SetActive(false);
            }
			hasMoved = true;
		}
	}
    
}
