using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBox : BaseInteractiveObjects
{
    public override void Interactive()
    {
        base.Interactive();

        Debug.Log("상호작용");
    }
}
