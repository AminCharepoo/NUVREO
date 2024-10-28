using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class BallDespawn : MonoBehaviour
{
    private bool onAlley = false;
    private Rigidbody bRB;
    public float stopMovementThreshold = 0.1f;
    float elapsedTime = 0f;
    public float stopTime = 4f;
    public float ultimateRemoveTimer = 20f;
    float ultimateTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        bRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("alley"))
        {
            onAlley = true;
            Debug.Log("Ball touch alley");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onAlley)
        {
            ultimateTime += Time.deltaTime;
            if (bRB.velocity.magnitude < stopMovementThreshold)
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
