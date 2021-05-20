using Google.XR.Cardboard;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    ///<summary>Max interaction distance.</summary>
    public float maxDistance = 10;
    public TargetManager targetIndicator;
    public Teleporter teleport;
    public Transform hand;

    private GameObject _lookingAt;
    private Vector3 _lookingWhere;
    private Rigidbody _itemInHand;

    // Update is called once per frame
    private void Update()
    {
        // Handling where the user is looking at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            _lookingWhere = hit.point;
            if (_lookingAt != hit.transform.gameObject)
            {
                _lookingAt?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
                _lookingAt = hit.transform.gameObject;
                _lookingAt.SendMessage("OnPointerEnter", SendMessageOptions.DontRequireReceiver);
            }
            targetIndicator.gameObject.SetActive(true);
            targetIndicator.transform.position = hit.point;
            targetIndicator.SetMaterial(!hit.transform.gameObject.CompareTag("Untagged"));
        }
        else
        {
            _lookingAt?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
            _lookingAt = null;
            targetIndicator.gameObject.SetActive(false);
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            if (_lookingAt != null)
            {
                if (_lookingAt.CompareTag("Floor"))
                {
                    teleport.Move(_lookingWhere);
                }
                if (_lookingAt.CompareTag("Interactable"))
                {
                    _lookingAt.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
                }
                if (_lookingAt.CompareTag("Item"))
                {
                    if (_itemInHand != null)
                    {
                        DropItem();
                    }
                    GrabItem();
                }
            }
        }

        // Holding an item
        if (_itemInHand != null)
        {
            _itemInHand.transform.position = hand.position;
            _itemInHand.transform.rotation = hand.rotation;
        }
    }

    private void GrabItem()
    {
        _itemInHand = _lookingAt.GetComponent<Rigidbody>();
        _itemInHand.isKinematic = true;
    }

    private void DropItem()
    {
        _itemInHand.isKinematic = false;
        _itemInHand = null;
    }
}
