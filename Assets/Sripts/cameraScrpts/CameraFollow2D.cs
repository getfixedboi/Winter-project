using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow2D : MonoBehaviour
{
    [Header ("Player references")]
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        cameraFollow();
    }
    private void cameraFollow()
    {
        if (player != null)
        {
            if(SpecialJumpMechanicCheck())
            {
                transform.position = new Vector3(player.transform.position.x,4, -10);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }
        }
    }
    private void ScpecialCameraMovement()
    {

    }

    private bool SpecialJumpMechanicCheck()
    {
        return SceneManager.GetActiveScene().buildIndex == 6;
    }
}
