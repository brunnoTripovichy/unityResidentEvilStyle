using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

	enum ActionButton { NewGame, LoadGame, Options, Quit };

	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] ActionButton actionButton;

	// Update is called once per frame
	void Update()
    {
		if (menuButtonController.index == thisIndex)
		{
			animator.SetBool("selected", true);

			if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{
				animator.SetBool("pressed", false);
				animatorFunctions.disableOnce = true;
				ProcessButtonAction();
			}
		}
		else
		{
			animator.SetBool("selected", false);
		}
    }

	private void ProcessButtonAction()
	{
		switch (actionButton)
		{
			case ActionButton.NewGame:
				SceneManager.LoadScene("Area001");
				break;
			case ActionButton.LoadGame:
				break;
			case ActionButton.Options:
				break;
			case ActionButton.Quit:
				Application.Quit();
				break;
			default:
				break;
		}
	}
}
