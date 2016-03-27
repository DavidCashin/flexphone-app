using UnityEngine;
using System.Collections;

public class FlowRateScript : MonoBehaviour {

    private ScrollingUVs_Layers lavaSpeed;
    private Vector2 lavaNertia;

	void Start () {
        lavaSpeed = GetComponent<ScrollingUVs_Layers>();
        lavaNertia = new Vector2(0.01f, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Keypad7)) //top-corner-bend-up (lava moves towards bottom-left)
        {
            lavaSpeed.uvAnimationRate = new Vector2(-0.1f, 0.1f);
            lavaNertia = new Vector2(-0.01f, 0.01f);
        }
        else if (Input.GetKey(KeyCode.Keypad9)) //top-corner-bend-down (lava moves towards top-right)
        {
            lavaSpeed.uvAnimationRate = new Vector2(0.1f, 0.1f);
            lavaNertia = new Vector2(0.01f, 0.01f);
        }
        else if (Input.GetKey(KeyCode.Keypad1)) //bottom-corner-bend-up (lava moves towards top-left)
        {
            lavaSpeed.uvAnimationRate = new Vector2(-0.1f, -0.1f);
            lavaNertia = new Vector2(-0.01f, -0.01f);
        }
        else if (Input.GetKey(KeyCode.Keypad3)) //bottom-corner-bend-down (lava moves towards bottom-right)
        {
            lavaSpeed.uvAnimationRate = new Vector2(0.1f, -0.1f);
            lavaNertia = new Vector2(0.01f, -0.01f);
        }
        else if (Input.GetKey(KeyCode.Keypad4)) //midline-bend-up (lava moves towards left)
        {
            lavaSpeed.uvAnimationRate = new Vector2(-0.1f, 0);
            lavaNertia = new Vector2(-0.01f, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad6)) //midline-bend-down (lava moves towards right)
        {
            lavaSpeed.uvAnimationRate = new Vector2(0.1f, 0);
            lavaNertia = new Vector2(0.01f, 0);
        }
        else
        {
            lavaSpeed.uvAnimationRate = lavaNertia; //lava continues visually in last direction moved
        }
    }
}
