using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Interactions
{
    public class PlayerCasting : MonoBehaviour
    {
        [SerializeField] private float rayDistance = 3f;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excludeLayerName = null;

        [SerializeField] private GameObject actionText;
        [SerializeField] private GameObject crossHair;

        private bool isTextActive;
        private bool doOnce;

        private RayManager raycastedObject;

        public string objectName;

        [SerializeField] private KeyCode actionKey = KeyCode.E;

        [SerializeField] private const string interactTag = "Interact";

        void Update()
        {

            RaycastHit Hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;
            if (Physics.Raycast(transform.position, fwd, out Hit, rayDistance, mask))
            {
                if (Hit.collider.CompareTag(interactTag))
                {
                    if (!doOnce)
                    {           
                        raycastedObject = Hit.collider.gameObject.GetComponent<RayManager>();
                    }
                    doOnce = true;
                    crossHair.SetActive(true);
                    actionText.SetActive(true);

                    if (Input.GetKeyDown(actionKey))
                    {
                        raycastedObject.OnInteraction();
                    }
                }
            }
            else
            {
                doOnce = false;
                crossHair.SetActive(false);
                actionText.SetActive(false);
            }
        }
    }
}
