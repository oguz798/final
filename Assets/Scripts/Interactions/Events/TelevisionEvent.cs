using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class TelevisionEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent myTriggerEnter;
        [SerializeField] private UnityEvent myTriggerExit;
        [SerializeField] private GameObject note;


        [SerializeField] private bool isTriggered = false;


        private void OnTriggerEnter(Collider other)
        {
            note.SetActive(true);
            if (!isTriggered && note.GetComponent<NotePickup>().triggerEvent)
            {        
                myTriggerEnter.Invoke();
                isTriggered = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (isTriggered)
            {
                myTriggerExit.Invoke();
                isTriggered = false;
            }
            
        }

    }
}
