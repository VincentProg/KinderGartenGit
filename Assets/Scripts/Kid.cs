using System;
using System.Collections;
using UnityEngine;

public class Kid : MonoBehaviour
{
    [HideInInspector] public int PlayerIndex;

    private Action<int, bool> afterKidMoved;
    private Coroutine kidMoveCoroutine;

    [SerializeField] private float moveTime;

    public void Initialize(int _playerIndex)
    {
        PlayerIndex = _playerIndex;
    }
    
    public void MoveKid(int _steps, float _stepSize, Action<int, bool> _afterKidMoved)
    {
        afterKidMoved = _afterKidMoved;
        
        if (kidMoveCoroutine != null)
            StopCoroutine(kidMoveCoroutine);

        kidMoveCoroutine = StartCoroutine(IEMoveKid(_steps, _stepSize));
    }

    private IEnumerator IEMoveKid(int _steps, float _stepSize)
    {
        if (moveTime == 0f)
            moveTime = 1f;
        
        float t = 0f;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + transform.forward * _steps * _stepSize;

        while (t <= 1f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            
            t += Time.deltaTime / moveTime;

            yield return null;
        }

        afterKidMoved?.Invoke(PlayerIndex, true);
    }
}
