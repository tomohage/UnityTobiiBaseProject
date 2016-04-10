using UnityEngine;

public class TobiiEyexArrangeController : MonoBehaviour {
    private Vector2 _eyePosition;
    void Awake ()
    {
    }
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        var lastEyePosition = gameObject.GetComponent<EyePositionDataComponent>().LastEyePosition;
        var lastGazePosition = gameObject.GetComponent<GazePointDataComponent>().LastGazePoint;
        _eyePosition = lastGazePosition.Display;
        // 両目が空いているときの挙動
        if (lastEyePosition.RightEye.IsValid && lastEyePosition.LeftEye.IsValid)
        {
            Debug.Log("Both: " + _eyePosition.x + ", " + _eyePosition.y);
        }
        // 右目が空いているときの挙動
        else if (lastEyePosition.RightEye.IsValid)
        {
            Debug.Log("Right: " + _eyePosition.x + ", " + _eyePosition.y);
        }
        // 左目が空いているときの挙動
        else if (lastEyePosition.LeftEye.IsValid)
        {
            Debug.Log("Left: " + _eyePosition.x + ", " + _eyePosition.y);
        }
        else
        {
            Debug.Log("None");
        }
    }
}
