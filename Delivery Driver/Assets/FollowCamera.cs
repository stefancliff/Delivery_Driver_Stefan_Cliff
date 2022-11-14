using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject thingToFollow; // inside of Unity, select inside the script component "The Car"
    // This things (cameras) postions should == the position of the car

    void LateUpdate() // this is to avoid any possible jittering
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10); // have to add the offset on the Z axis otherwise we will won't see anything
    }
}
