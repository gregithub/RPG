using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D questionCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
        cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.onLayerChange += OnLayerChanged;
	}
	
	
	void OnLayerChanged (Layer newLayer) {
        switch (newLayer)
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
//TODO consider de-registering OnLayerChanged on leaving all game scenes