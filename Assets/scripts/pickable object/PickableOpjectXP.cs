using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableOpjectXP : PickableObjecBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TriggerResponse(Collider _other)
    {
        base.TriggerResponse(_other);

        if (_other.gameObject==PlayerMovement.Instance.gameObject)
        {
            PlayerMovement.Instance.XP += 5;
        }

    }
}
