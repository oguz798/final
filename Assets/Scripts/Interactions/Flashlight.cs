using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
	public class Flashlight : MonoBehaviour
	{

		public AudioSource switchSound;
		public GameObject flashlight;
		private Light light;
		private bool firstTime = false;

		
		[SerializeField] private GameObject textObject;


		[SerializeField] private Inventory inventory = null;
		private void Awake()
		{
			light = flashlight.GetComponent<Light>();
			light.enabled = false;
			textObject.GetComponent<Text>().text = "";
		}
		void Update()
		{
            if (!firstTime && inventory.hasFlashLight)
            {
				StartCoroutine(FlashlightNotification());
				firstTime = true;
			}
			if (Input.GetKeyDown(KeyCode.F))
			{
				if (inventory.hasFlashLight)
				{
					
					switchSound.Play();

					if (light.enabled)
					{
						light.enabled = false;
					}
					else
					{
						light.enabled = true;
					}
				}
                else
                {
					StartCoroutine(Notification());
				}
			}
		}

		private IEnumerator Notification()
        {
			textObject.SetActive(true);
			textObject.GetComponent<Text>().text = "I must find a flashlight";

			yield return new WaitForSeconds(2.0f);
			textObject.SetActive(false);
			textObject.GetComponent<Text>().text = "";
        }

		private IEnumerator FlashlightNotification()
		{
			textObject.GetComponent<Text>().text = "Press 'F' to on/off the flashlight";
			textObject.SetActive(true);

			yield return new WaitForSeconds(1.0f);
			textObject.SetActive(false);
			textObject.GetComponent<Text>().text = "";

		}
	}
}
