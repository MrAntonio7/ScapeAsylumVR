using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetGrabable : MonoBehaviour
{

    //public GameObject grabable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CogerRecto()
    {
        
        transform.eulerAngles = new Vector3(0,0,90);
    }

}
