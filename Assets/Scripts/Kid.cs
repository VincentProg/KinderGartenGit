using System;
using System.Collections;
using UnityEngine;

public class Kid : MonoBehaviour
{
    private Action<bool> afterKidMoved;
    private Coroutine kidMoveCoroutine;

    private bool isChoked;

    [SerializeField] private float moveTime;

    private bool isDead;

    private bool isChocking;
    public float maxTimeChocking;
    private float currentTimeChocking;
    private bool isInChockState;
    public Color startColor;
    public Color redColor;
    public SpriteRenderer headSprite;

    ObjectShake shaker;

    public GameObject bodyDeath;

    private void Start()
    {
        shaker = GetComponentInChildren<ObjectShake>();
    }
    private void Update()
    {
        if (isDead) return;

        if (isChocking)
        {
            Chocking();
        }
    }


    public void MoveKid(int _steps, float _stepSize, Action<bool> _afterKidMoved)
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

        afterKidMoved?.Invoke(true);
    }


    public void StartChocking()
    {
        isChocking = true;
        isInChockState = true;
        shaker.StartShake();
    }

    private void Chocking()
    {
        if (isInChockState)
        {
            currentTimeChocking += Time.deltaTime / maxTimeChocking;
            headSprite.color = Color.Lerp(startColor, redColor, currentTimeChocking);
            shaker.SetIntensity(currentTimeChocking);

            if (currentTimeChocking >= 1)
            {
                currentTimeChocking = 1;
                Death();
            }
        } else
        {
            currentTimeChocking -= Time.deltaTime / maxTimeChocking;
            headSprite.color = Color.Lerp(startColor, redColor, currentTimeChocking);
            shaker.SetIntensity(currentTimeChocking);
            if (currentTimeChocking <= 0)
            {
                currentTimeChocking = 0;
                isChocking = false;
            }
        }
    }

    public void StopChocking()
    {
        isInChockState = false;
        shaker.StopShake();
    }

    private void Death()
    {
        isInChockState = false;
        isChocking = false;
        shaker.StopShake();
        bodyDeath.SetActive(true);
        Rigidbody rb = headSprite.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(new Vector3(3, 5), ForceMode.Impulse);
        rb.AddTorque(new Vector3(0, 0, -5));

    }
}
