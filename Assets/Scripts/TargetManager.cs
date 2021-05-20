using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    ///<summary>Material used when looking at an interactable item or walkable surface.</summary>
    public Material validMaterial;
    ///<summary>Material used when looking at any other item or surface.</summary>
    public Material invalidMaterial;

    private Renderer _targetRenderer;


    private void Awake()
    {
        _targetRenderer = GetComponent<Renderer>();
    }

    ///<summary>Is the user looking at an interactable or walkable surface?</summary>
    public void SetMaterial(bool lookedAt)
    {
        if (validMaterial != null && invalidMaterial != null)
        {
            _targetRenderer.material = lookedAt ? validMaterial : invalidMaterial;
        }
    }
}
