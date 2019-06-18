using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxConfig : MonoBehaviour {

	public float skyBoxRotSpeed = 1f;
    private bool rotationEnabled = true;
	// Use this for initialization
	void Start () {
       
    }

    private void OnEnable()
    {
        GameStateManager.pauseGame += RotationDisabled;
        GameStateManager.resumeGame += RotationEnabled;
    }

    private void OnDisable()
    {
        GameStateManager.pauseGame -= RotationDisabled;
        GameStateManager.resumeGame -= RotationEnabled;

    }

    // Update is called once per frame
    void Update ()
	{
        if(rotationEnabled)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyBoxRotSpeed);
        }
    }


    /// Disabled Skybox rotation

    private void RotationDisabled()
    {
        rotationEnabled = false;
    }


    /// Enables SkyBox rotation

    private void RotationEnabled()
    {
        rotationEnabled = true;
    }
}
