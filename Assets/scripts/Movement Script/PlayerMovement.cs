using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public void IAAccelerate(InputAction.CallbackContext context)
    {
        Vector2 MoveValue = context.ReadValue<Vector2>();//<vector2> is a carats
        Debug.Log (MoveValue); 
        transform.Translate(MoveValue.x, 0, MoveValue.y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
