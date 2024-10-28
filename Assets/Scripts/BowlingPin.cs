using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class BowlingPin : MonoBehaviour
{
    private bool isFallen = false;
    public float fallenThreshold = 45f;
    private Rigidbody RB;
    public float stopMovementThreshold = 0.1f;
    float elapsedTime = 0f;
    public float stopTime = 2f;
    public float ultimateRemoveTimer = 6f;
    float ultimateTime;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isFallen && (Mathf.Abs(transform.eulerAngles.x) > fallenThreshold || Mathf.Abs(transform.eulerAngles.z) > fallenThreshold))
        {
            isFallen = true;
            Debug.Log("Pin has Fallen!");
            if (BowlingManager.Instance != null)
            {
                BowlingManager.Instance.AddScore(1);
                Debug.Log("Score added!");
            }
            else
            {
                Debug.LogError("BowlingManager.Instance is null. Score not added.");
            }

            ultimateTime += Time.deltaTime;
        }

        if (isFallen)
        {
            if (RB.velocity.magnitude < stopMovementThreshold)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0f;
            }

            if ((elapsedTime >= stopTime) || (ultimateTime >= ultimateRemoveTimer))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
