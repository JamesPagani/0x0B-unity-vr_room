using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [HideInInspector]public Material normalMaterial;
    public Material selectedMaterial;
    private Renderer _itemRenderer;

    private void Start()
    {
        _itemRenderer = GetComponent<Renderer>();
        normalMaterial = _itemRenderer.material;
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    private void SetMaterial(bool gazedAt)
    {
        if (normalMaterial != null && selectedMaterial != null)
        {
            _itemRenderer.material = gazedAt ? selectedMaterial : normalMaterial;
        }
    }
}
