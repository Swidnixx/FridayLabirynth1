using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer myRenderPlane;
    Camera playerCam;
    Camera myCamera;
    PortalTeleport teleport;

    private void Awake()
    {
        playerCam = Camera.main;
        myCamera = GetComponentInChildren<Camera>();
        teleport = GetComponentInChildren<PortalTeleport>();
        teleport.player = playerCam.transform.parent;
        teleport.receiver = linkedPortal.GetComponentInChildren<PortalTeleport>().transform;
    }

    private void Start()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        linkedPortal.myRenderPlane.material.SetTexture("_MainTex", rt);
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix
            * playerCam.transform.localToWorldMatrix;

        myCamera.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
    }
}
