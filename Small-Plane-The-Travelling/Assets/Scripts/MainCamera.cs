using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public GameObject Player;
    public bool gameStarted = false;
    public bool cameraLockToPlayer = false;
    private Vector3 currentAngle;
    public int cameraType = 0;
    public Vector3 cameraMenuPosition;
    public float cameraTilt = 10;
    private bool cameraEndScreen = false;

    /// Used to initialise curretn class

    void Start ()
    {
        currentAngle = transform.eulerAngles;
        transform.position = cameraMenuPosition;
    }


    /// Called when this script is enabled

    private void OnEnable()
    {
        GameStateManager.startGame += StartGame;
        GameStateManager.gameOver += CameraMoveGameOver;
    }


    /// Called when this script is enabled

    private void OnDisable()
    {
        GameStateManager.startGame -= StartGame;
        GameStateManager.gameOver -= CameraMoveGameOver;
    }


    void Update () {

	    if (Input.GetKeyDown(KeyCode.E))
	    {
	        switchCamera();
	    }

	}


    void LateUpdate()
    {
        if (gameStarted)
        {
            LerpCameraToGameStart();
        }

        if (cameraLockToPlayer && !cameraEndScreen)
        {
            if (cameraType == 0)
            {
                transform.position =
                    new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, Time.deltaTime * 5),
                        Mathf.Lerp(transform.position.y, Player.transform.position.y + 20, Time.deltaTime + 5), Player.transform.position.z - 80);
                transform.eulerAngles = new Vector3(cameraTilt, 0, 0);
            }
            else
            {
                transform.position =
                    new Vector3(250,
                        90, Player.transform.position.z - 120);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (cameraEndScreen)
        {
            LerpCameraToGameEnd();
        }
    }

    void switchCamera()
    {
        if (cameraType == 0)
        {
            cameraType = 1;
        }
        else
        {
            cameraType = 0;
        }
    }

    public void StartGame()
    {
        gameStarted = true;
    }

   
    private void LerpCameraToGameStart()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, Time.deltaTime/1.5f),
                Mathf.Lerp(transform.position.y, Player.transform.position.y + 20, Time.deltaTime/1.5f),
                Mathf.Lerp(transform.position.z, Player.transform.position.z - 80, Time.deltaTime/1.5f));

        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, cameraTilt, Time.deltaTime/1.5f),
            Mathf.LerpAngle(currentAngle.y, 0, Time.deltaTime/1.5f),
            Mathf.LerpAngle(currentAngle.z, 0, Time.deltaTime));

        transform.eulerAngles = currentAngle;

        if (transform.position.x > Player.transform.position.x - 0.5f)
        {
            gameStarted = false;
            cameraLockToPlayer = true;
            GameStateManager.current.LoadAllStartGameComponents();
        }
    }

    private void LerpCameraToGameEnd()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, Time.deltaTime/1.5f),
                Mathf.Lerp(transform.position.y, Player.transform.position.y + 60, Time.deltaTime/1.5f),
                Mathf.Lerp(transform.position.z, Player.transform.position.z - 80, Time.deltaTime/1.5f));

        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, cameraTilt, Time.deltaTime/1.5f),
            Mathf.LerpAngle(currentAngle.y, 0, Time.deltaTime/1.5f),
            Mathf.LerpAngle(currentAngle.z, 0, Time.deltaTime));

        transform.eulerAngles = currentAngle;
    }

    public void CameraMoveGameOver()
    {
        cameraEndScreen = true;
    }
}
