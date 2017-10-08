using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AnimationBuffer : MonoBehaviour {
    // maps order of animation to corresponding face 
    private static Dictionary<int, int> buffer;
    // maps face # to an animation
    private Dictionary<int, GameObject> animationList; 

    public static Dictionary<int, int> GetBuffer()
    {
        return buffer;
    }

    public static void SetBuffer(Dictionary<int, int> value)
    {
        buffer = value;
    }

    // Use this for initialization
    void Start () {
        SetBuffer(new Dictionary<int, int>());
        animationList = new Dictionary<int, GameObject>();
        SetAnimations();
     }

    // input all animations
    void SetAnimations()
    {
        animationList.Add(0, GameObject.FindGameObjectWithTag("Turrell"));
    }

    // activates animation corresponding to that face
    void activateAnimation(int face)
    {
        GameObject nextAnim = animationList[face];
        Assert.IsNotNull(value: nextAnim);
        nextAnim.GetComponent<Animator>();
    }

    void Update()
    {
        if(buffer.Count >= 1)
        {
            foreach(int animationNumber in buffer.Values)
            {
                activateAnimation(animationNumber);
            }
            buffer.Clear();
        }
    }
}
