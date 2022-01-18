using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    //Variable for our look at target
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        //tell gameobject to look at the target
        //this.transform.LookAt(target);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.LookAt(target);
        }
    }
}
