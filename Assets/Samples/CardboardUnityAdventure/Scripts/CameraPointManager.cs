using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointManager : MonoBehaviour
{
    public LayerMask ReticleInteractionLayerMask = 1 << _RETICLE_INTERACTION_DEFAULT_LAYER;
    private const int _RETICLE_INTERACTION_DEFAULT_LAYER = 8;

    private const float _RETICLE_MAX_DISTANCE = 20.0f;
    private GameObject _gazedAtObject = null;

    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer;
    [Range(0, 1)]
    [SerializeField] private float distancePointerObject = 0.95f;
    private float scaleSize = 0.025f;

    private void Start ()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection ()
    {
        _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
    }

    private void Update ()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, _RETICLE_MAX_DISTANCE))
        {
            if(_gazedAtObject != hit.transform.gameObject)
            {
                if(IsInteractive(_gazedAtObject))
                {
                    _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
                }

                _gazedAtObject = hit.transform.gameObject;

                if(IsInteractive(_gazedAtObject))
                {
                    _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                    GazeManager.Instance.StartGazeSelection();
                }
            }

            if(IsInteractive(hit.transform.gameObject))
                PointerOnGaze(hit.point);
            else
                PointerOutGaze();
        }
        else
        {
            if(IsInteractive(_gazedAtObject))
            {
                _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            }

            _gazedAtObject = null;
        }

        if(Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            if(IsInteractive(_gazedAtObject))
            {
                _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
            }
        }       
    } 
   
    private bool IsInteractive (GameObject gameObject)
    {
        return (1 << gameObject?.layer & ReticleInteractionLayerMask) != 0;
    }

    private void PointerOutGaze ()
    {
        pointer.transform.localScale = Vector3.one * 0.1f;
        pointer.transform.parent.transform.localPosition = new Vector3(0, 0, maxDistancePointer);
        pointer.transform.parent.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }

    private void PointerOnGaze (Vector3 hitPoint)
    {
        float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scaleFactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitPoint, distancePointerObject);
    }

    private Vector3 CalculatePointerPosition (Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);

        return new Vector3(x, y, z);
    }
}
