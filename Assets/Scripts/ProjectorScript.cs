using UnityEngine;

///<summary>Turns on or off the projector.</summary>
public class ProjectorScript : MonoBehaviour
{
    public GameObject particles;
    public void Interact()
    {
        particles.SetActive(!particles.activeSelf);
    }
}
