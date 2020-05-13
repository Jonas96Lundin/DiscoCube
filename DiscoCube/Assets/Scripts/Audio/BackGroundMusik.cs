using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusik : MonoBehaviour
{
    [SerializeField]
    string music;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play(music);
    }

}
