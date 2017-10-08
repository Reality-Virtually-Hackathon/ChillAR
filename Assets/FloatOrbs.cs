//need to add random break to reset tempPos
//need to limit movement to frame

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class FloatOrbs : MonoBehaviour
{
    // User Inputs
    public float frequency = 1f;
    //public float amplitude = 5f;
    public float speed = 0.1f;

    public Transform Float_Orb;

    public Vector3 dest;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    const float x_upper = 30f;
    const float y_upper = 30f;
    const float z_upper = 30f;
    const float x_lower = 0f;
    const float y_lower = 0f;
    const float z_lower = 0f;


    int y_dir = 1;
    int x_dir = 1;
    int z_dir = 1;

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        System.Random rndff = new System.Random();
        int fforb = rndff.Next(0, 100);

        {
            for (int i = 0; i < 5; i++)
            {
                GameObject orb;
                orb = Instantiate(Float_Orb, new Vector3(i * 2.0F, 0, 0), Quaternion.identity).gameObject;
                FloatOrbs ff = orb.GetComponent<FloatOrbs>();
                ff.frequency = fforb / 100f;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("updating");
        System.Random rndy = new System.Random();
        int y = rndy.Next(-5, 10);

        System.Random rndx = new System.Random();
        int x = rndx.Next(0, 20);

        System.Random rndz = new System.Random();
        int z = rndz.Next(-10, 30);

        // Float up/down with a Sin()
        //tempPos = posOffset;
        tempPos.y += y * y_dir * speed;
        tempPos.x += x * x_dir * speed;
        tempPos.z += z * z_dir * speed;

        /*tempPos.y += amplitude * y * y_dir * speed;
		tempPos.x += amplitude * x * x_dir * speed;
		tempPos.z += amplitude * z * z_dir * speed;
*/

        if (tempPos.y >= y_upper)
        {
            tempPos.y = y_upper;
            y_dir = -1;
        }
        if (tempPos.x >= x_upper)
        {
            tempPos.x = x_upper;
            x_dir = -1;
        }
        if (tempPos.z >= z_upper)
        {
            tempPos.z = z_upper;
            z_dir = -1;
        }

        if (tempPos.y <= y_lower)
        {
            tempPos.y = y_lower;
            y_dir = 1;
        }
        if (tempPos.x <= x_lower)
        {
            tempPos.x = x_lower;
            x_dir = 1;
        }
        if (tempPos.z <= z_lower)
        {
            tempPos.z = z_lower;
            z_dir = 1;
        }
        Debug.Log(tempPos);
        transform.position = tempPos;

    }
}