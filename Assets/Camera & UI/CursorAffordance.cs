﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorAffordance : MonoBehaviour {

    
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D questionCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(96, 96);
    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
        cameraRaycaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        switch (cameraRaycaster.layerHit)
        {
            case Layer.Enemy:
                Cursor.SetCursor(attackCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(questionCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.LogError("Don't know what cursor to show");
                return;
        }
    }       
}
