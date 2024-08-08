using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningDemo : MonoBehaviour
{
    bool testBoolean = false;
    int testinteger = 2;
    float testFloat = 1.0f;
    string testString = "Test";
    
    // Start is called before the first frame update
    void Start()
    {
        float x = FindSinValue(45f);
        Debug.Log(x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float FindSinValue(float incomingAngle)
    {
        float result;
        result = Mathf.Sin(incomingAngle);
        return result;
        
    }
}
