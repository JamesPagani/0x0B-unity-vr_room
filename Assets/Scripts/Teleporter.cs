using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Handler for the camera's teleporting.</summary>
public class Teleporter : MonoBehaviour
{
    ///<summary>Move the camera to the desired position.</summary>
    public void Move(Vector3 dest)
    {
        dest.y = 0f;
        this.transform.position = dest;
    }
}
