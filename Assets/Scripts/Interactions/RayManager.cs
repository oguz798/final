using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
    public class RayManager : MonoBehaviour
    {
        [SerializeField] private bool noKeyDoor = false;
        [SerializeField] private bool bathroomDoor = false;
        [SerializeField] private bool keyObj = false;
        [SerializeField] private bool flashLight = false;

        [SerializeField] private Inventory inventory;

        private DoorOpen doorObject;

        private void Start()
        {
            if (bathroomDoor || noKeyDoor)
            {
                doorObject = GetComponent<DoorOpen>();
            }         
        }
        public void OnInteraction()
        {
            if (bathroomDoor)
            {
                doorObject.PlayAnimation();
            }
            else if (keyObj)
            {
                inventory.hasKey = true;
                Debug.Log(gameObject);
                gameObject.SetActive(false);
            }
            else if (flashLight)
            {
                inventory.hasFlashLight = true;
                gameObject.SetActive(false);

            }
            else if (noKeyDoor)
            {
                doorObject.NoKeyDoor();
            }
        }
      
    }
}
