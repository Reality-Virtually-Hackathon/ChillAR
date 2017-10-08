using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour {
    Renderer rend;
    float transitionRate;
    Color[] colors = { Color.black, Color.red, Color.blue, Color.cyan, Color.green, Color.magenta };
    public int currFace; 

    // initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        transitionRate = 2f;
    }
    // Update is called once per frame
    void Update() {
        currFace = getFace(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        rend.material.SetColor("_Color", Color.Lerp(rend.material.color, colors[currFace], Time.deltaTime * transitionRate));
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked " + currFace + "!");
            AnimationBuffer.GetBuffer().Add(AnimationBuffer.GetBuffer().Count + 1, currFace);
        }
    }


    // determines which face is facing camera based on euler angles of rotation
    public int getFace(double x, double y, double z)
    {
        if (is360(x) && is360(y))
            return 0; // black, merge.com
        else if ((is270(x) && is180(y) && is180(z)) || (is360(x) && is270(y) && is90(z)) || (is90(x) && is360(y) && is180(z)) || (is360(x) && is90(y) && is270(z)))
            return 1; // white, merge title
        else if (is180(y) && is360(x))
            return 2; // blue, <.>
        else if ((is360(x) && ((is270(y) && is360(z)) || (is90(y) && is180(z)))) || (is90(x) && is360(y) && is90(z)) || (is270(x) && is180(y) && is90(z)))
            return 3; // cyan, alien
        else if ((is360(x) && is90(y) && is90(z)) || (is90(x) && is180(y) && is180(z)) || (is360(x) && is270(y) && is270(z)) || (is270(x) && (is360(y) ||is180(y)) && (is360(z) || is270(z))))
            return 4; // green, illuminati
        else
            return 5; // grey, moon
    }

    // determines if euler angle is within ranges specified with +/- 45 degree uncertainty
    bool is360(double angle)
    {
        return ((315 <= angle && angle <= 360) || (0 <= angle && angle <= 45));
    }
    bool is270(double angle)
    {
        return (225 <= angle && angle <= 315);
    }
    bool is180(double angle)
    {
        return (135 <= angle && angle <= 225);
    }
    bool is90(double angle)
    {
        return (45 <= angle && angle <= 135);
    }
}
