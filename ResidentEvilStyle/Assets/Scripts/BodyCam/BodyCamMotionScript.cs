using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCamMotionScript : MonoBehaviour
{

    Vector3 bodyCameraCurrentPos;
    Vector3 bodyCameraOrigin;
    Vector3 bodyCameraTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        bodyCameraOrigin = gameObject.transform.localPosition;
        bodyCameraCurrentPos = bodyCameraOrigin;
    }

    public void HeadBob(float xIntensity, float yIntenity, float z)
    {
        float t_aim_adjust = 1f;
        //if (isAiming) t_aim_adjust = 0.1f;
        bodyCameraTargetPos = bodyCameraCurrentPos + new Vector3(Mathf.Cos(z) * xIntensity * t_aim_adjust, Mathf.Sin(z * 2) * yIntenity * t_aim_adjust, 0);
    }

    public void IdleBob(float speed)
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, bodyCameraTargetPos, Time.deltaTime * speed * 0.2f);
    }

    #region Private Methods


    #endregion
}
