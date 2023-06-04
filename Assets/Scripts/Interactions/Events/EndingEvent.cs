using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EndingEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent myTriggerEnter;
    [SerializeField] private UnityEvent myTriggerExit;

    [SerializeField] private bool isTriggered = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
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
