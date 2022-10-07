using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    public override void Pick()
    {
        GameManager.Instance.AddDiamond();
        Debug.Log("Podniesiono diament");
        base.Pick();
    }
}
