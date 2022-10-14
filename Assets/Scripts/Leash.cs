using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Leash : MonoBehaviour
{
    public static Leash instance;
    [Range(0, 2)]
    int stateP1;
    int stateP2;
    // 0 = mou
    // 1 = tendu
    // 2 = très tendu

    [SerializeField]
    LineRenderer l1, l2;
    [SerializeField]
    Transform pos1, pos2, posKid;

    Kid kid;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        kid = FindObjectOfType<Kid>();
    }

    public void Update()
    {
        l1.SetPosition(0, pos1.position);
        l1.SetPosition(1, posKid.position);
        l2.SetPosition(0, pos2.position);
        l2.SetPosition(1, posKid.position);
    }

    public void ChangeState(int idPlayer, int idState)
    {
        if (idPlayer == 1)
            stateP1 = idState;
        else
            stateP2 = idState;

        if (stateP1 == 1 && stateP2 == stateP1)
        {
            kid.StartChocking();
        }
        else
        {
            kid.StopChocking();
        }
    }



}
