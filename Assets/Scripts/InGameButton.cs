using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameButton : MonoBehaviour
{
    public enum ActionType { PRESS, MAINTAIN, MAINTAIN_ONCE }
    public ActionType type;
    public KeyCode key;
    public float maintainTimer;
    private float timePressed;

    bool isPressed;

    public UnityEvent successPressEvent;
    public UnityEvent unpressEvent;

    private bool isEnded;

    private void Update()
    {

        if (Input.GetKeyDown(key))
        {
            isPressed = true;
        }
        if (Input.GetKeyUp(key))
        {
            isPressed = false;
            if(type == ActionType.MAINTAIN_ONCE)
            {
                timePressed = 0;
            }
            unpressEvent.Invoke();
        }

        if (isPressed)
        {
            DoActionPress();
        }
    }

    private void DoActionPress()
    {
        if (isEnded) return;

        switch (type)
        {
            case ActionType.PRESS:
                OnSuccess();
                break;
            default:
                timePressed += Time.deltaTime;
                Debug.Log(timePressed);
                if (timePressed >= maintainTimer)
                {
                    OnSuccess();
                }
                break;
        }
    }

    private void DoActionUnpress()
    {
        unpressEvent.Invoke();
    }

    private void OnSuccess()
    {
        Debug.Log("Success");
        isEnded = true;
        successPressEvent.Invoke();
    }

    public void ResetButton()
    {
        timePressed = 0;
        isEnded = false;
    }

    public void SwitchType(ActionType nextType)
    {
        type = nextType;
    }
}
