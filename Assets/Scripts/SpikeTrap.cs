using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpikeTrap : Trap
{
    private bool _isTrapActive = false;

    protected override void KillPlayer(IPlayer player)
    {
        if (_isTrapActive)
        {
            base.KillPlayer(player);
        }
    }
    public override void PlayAnimation(string name) //проигрывает анимацию spike
    { 
        if (!_isTrapActive) 
        {
            base.PlayAnimation(name);
            _isTrapActive = true;
        }        
    }
}


