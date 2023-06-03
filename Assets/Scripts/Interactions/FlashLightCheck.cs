using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{ 
    public class FlashLightCheck : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private AudioSource doorSlam;
        [SerializeField] private GameObject door;

        private bool isTriggered = false;

        private Animator doorAnim;

        private void Start()
        {
            doorAnim = door.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (inventory.hasFlashLight && !isTriggered)
            {
                doorSlam.Play();
                doorAnim.Play("MainDoorClose");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            isTriggered = true;
        }
    }
}
