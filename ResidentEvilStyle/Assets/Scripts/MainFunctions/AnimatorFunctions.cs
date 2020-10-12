using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] BodyCamScript bodyCamScript;

	[SerializeField] MenuButtonController menuButtonController;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound)
	{
		if(!disableOnce)
		{
			menuButtonController.audioSource.PlayOneShot(whichSound);
		}
		else
		{
			disableOnce = false;
		}
	}

	void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	void DisableBodyCam()
	{
		if (bodyCamScript.bodyCam != null)
		{
			bodyCamScript.bodyCam.SetActive(false);
		}
		
	}

	void EnableBodyCam()
	{
		if (bodyCamScript.bodyCam != null)
		{
			bodyCamScript.bodyCam.SetActive(true);
		}
	}
}	
