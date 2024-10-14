using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private int playerCount;

    public GameObject leftBarrierCollider;
    public GameObject leftBarrierTrigger;
    public GameObject rightBarrierCollider;
    public GameObject rightBarrierTrigger;

    public float offsetY;

    public Camera mainCamera;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        SetCameraPos();
        SetBarrierPositions();
    }
    
    private void SetCameraPos()
    {
        if (playerCount == 2)
        {
            Vector3 middle = (player1.position + player2.position) / 2f;

            mainCamera.transform.position = new Vector3(middle.x, middle.y + offsetY, mainCamera.transform.position.z);
        }
    }

    private void SetBarrierPositions()
    {
        rightBarrierCollider.transform.position = new Vector2(mainCamera.transform.position.x + screenBounds.x + 0.5f, mainCamera.transform.position.y);
        rightBarrierTrigger.transform.position = new Vector2(mainCamera.transform.position.x + screenBounds.x + 0.5f, mainCamera.transform.position.y);
        leftBarrierCollider.transform.position = new Vector2(mainCamera.transform.position.x - screenBounds.x - 0.5f, mainCamera.transform.position.y);
        leftBarrierTrigger.transform.position = new Vector2(mainCamera.transform.position.x - screenBounds.x - 0.5f, mainCamera.transform.position.y);
    }
}
