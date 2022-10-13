using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Leash : MonoBehaviour
{
    public static Leash instance;

    [SerializeField]
    LineRenderer l1, l2;
    [SerializeField]
    Transform pos1, pos2, posKid;

    Kid kid;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
       kid = FindObjectOfType<Kid>();
    }

        if(PlayersManager.instance.buttonManagerP1.pressionLevel == 1 && PlayersManager.instance.buttonManagerP2.pressionLevel == 1)
        {
            Debug.Log(currenTimerWroughtUp);
            currenTimerWroughtUp += Time.deltaTime;
            if(currenTimerWroughtUp >= maxTimeWroughtUp)
            {
                OnMaxTimeWroughtUpdReached();
            }
        } else
        {
            currenTimerWroughtUp = 0;
        }

        l1.SetPosition(0, pos1.position);
        l1.SetPosition(1, posKid.position);
        l2.SetPosition(0, pos2.position);
        l2.SetPosition(1, posKid.position);
    }

    public void OnMaxTimeWroughtUpdReached()
    {
        maxTimeWroughtUpReached.Invoke();
        isEnded = true;
        Debug.Log("ChildDead");
    }

}
