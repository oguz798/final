using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
    public class RayManager : MonoBehaviour
    {
        [SerializeField] private bool noKeyDoor = false;
        [SerializeField] private bool bedroomDoor = false;
        [SerializeField] private bool roomDoor = false;
        [SerializeField] private bool keyRoom = false;
        [SerializeField] private bool keyBedroom = false;
        [SerializeField] private bool flashLight = false;
        [SerializeField] private bool notepad = false;

        [SerializeField] private Inventory inventory;

        private DoorOpen doorObject;
        private NotePickup noteObject;

        [SerializeField] private GameObject notificationText;
        private string text;

        private void Start()
        {
            if (bedroomDoor || noKeyDoor || roomDoor)
            {
                doorObject = GetComponent<DoorOpen>();
            } 
            else if (notepad)
            {
                noteObject = GetComponent<NotePickup>();
            }
        }
        public void OnInteraction()
        {
            if (bedroomDoor)
            {
                doorObject.KeyBedroom();
            }
            else if(roomDoor)
            {
                doorObject.KeyRoom();
            }
            else if (keyRoom)
            {
                inventory.hasKeyRoom = true;    
                text = "I picked up the small bedroom key.";
                StartCoroutine(Notification());

            }
            else if (keyBedroom)
            {
                inventory.hasKeyBedroom = true;
                text = "I picked up the main bedroom key.";
                StartCoroutine(Notification());
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
            else if (notepad)
            {
                if (!noteObject.isOpen)
                {
                    noteObject.ShowNote();
                }
                else
                {
                    noteObject.DisableNote();

                }
            }
        }

        private IEnumerator Notification()
        {
            notificationText.GetComponent<Text>().text = text;
            notificationText.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(2.0f);
            notificationText.SetActive(false);
            notificationText.GetComponent<Text>().text = "";
            gameObject.SetActive(false);
        }

    }
}
