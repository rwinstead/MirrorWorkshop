using Mirror;
using UnityEngine;
using Cinemachine;

public class PikaMovement : NetworkBehaviour
{
    public Transform player;
    public CinemachineFreeLook vcam;

    public override void OnStartLocalPlayer()
    {
        vcam = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineFreeLook>();
        player = gameObject.transform;
        vcam.Follow = player;
        vcam.LookAt = player;

    }

    void Update()
    {
        if (!isLocalPlayer) { return; }

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);
    }


}