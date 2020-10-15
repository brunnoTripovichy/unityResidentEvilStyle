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
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        pauseMenuScript.FadeOut();
        pauseMenuScript.SetPauseMenuState(false);
        bodyCamScript.bodyCam.SetActive(true);
        //tankControls.canMove = true;
        gameIsPaused = false;
    }

    void Pause()
    {
        buttonController.index = 0;
        bodyCamScript.bodyCam.SetActive(false);
        //tankControls.canMove = false;
        pauseMenuScript.SetPauseMenuState(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
