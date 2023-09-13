using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Singleton<CameraMovement>
{
    protected GameObject _focusObject = null;
    public void SetFocus(GameObject gameObject)
    {
        _focusObject = gameObject;
    }
    private void FixedUpdate()
    {
        if(_focusObject != null)
        {
            Vector3 LerpTarget = _focusObject.transform.position;
            LerpTarget += new Vector3(0, 0, transform.position.z - LerpTarget.z);
            transform.position = Vector3.Lerp(transform.position, LerpTarget, Time.fixedDeltaTime);
        }
    }
}
