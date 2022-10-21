using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform linkedPortal;
    public Camera playerCam;
    public Camera myCamera;

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix
            * playerCam.transform.localToWorldMatrix;

        myCamera.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
    }
}
