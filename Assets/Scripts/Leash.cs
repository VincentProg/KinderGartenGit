using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Leash : MonoBehaviour
{
    [Range(0,2)]
    int stateP1;
    int stateP2;
    // 0 = mou
    // 1 = tendu
    // 2 = très tendu

    public float maxTimeWroughtUp;
    private float currenTimerWroughtUp;
    public UnityEvent maxTimeWroughtUpReached;
    private bool isEnded;

    public void Update()
    {
        if (isEnded) return;

        if(stateP1 == 2 && stateP2 == 2)
        {
            currenTimerWroughtUp += Time.deltaTime;
            if(currenTimerWroughtUp >= maxTimeWroughtUp)
            {
                OnMaxTimeWroughtUpdReached();
            }
        } else
        {
            currenTimerWroughtUp = 0;
        }
    }

    public void ChangeStateP1(int IDstate)
    {
        stateP1 = IDstate;
    }

    public void ChangeStateP2(int IDstate)
    {
        stateP2 = IDstate;
    }

    public void OnMaxTimeWroughtUpdReached()
    {
        maxTimeWroughtUpReached.Invoke();
    }

}
