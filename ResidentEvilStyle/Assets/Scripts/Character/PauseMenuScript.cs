using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField] BodyCamScript bodyCamScript;
    [SerializeField] PauseMenuBehaviorScript pauseMenuScript;
    [SerializeField] TankControls tankControls;
    [SerializeField] MenuButtonController buttonController;

    public static bool gameIsPaused = false;

    private bool isOpen = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                StartCoroutine(Resume());
            }
            else
            {
                Pause();
            }
        }
    }

    public IEnumerator Resume()
    {
        Time.timeScale = 1f;
        bodyCamScript.bodyCam.SetActive(true);
        tankControls.canMove = true;
        gameIsPaused = false;
        pauseMenuScript.FadeOut();
        yield return new WaitForSeconds(0.5f);
        pauseMenuScript.SetPauseMenuState(false);
    }

    void Pause()
    {
        buttonController.index = 0;
        bodyCamScript.bodyCam.SetActive(false);
        tankControls.canMove = false;
        pauseMenuScript.SetPauseMenuState(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
