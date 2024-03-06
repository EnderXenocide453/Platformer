using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointEffector2D))]
public class BlastingObject : MonoBehaviour
{
    [SerializeField] float activatingForce = 1;
    [SerializeField] float blastingTime = 0.5f;
    
    Rigidbody2D _body;
    PointEffector2D _effector;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _effector = GetComponent<PointEffector2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_body.velocity.magnitude >= activatingForce) {
            StartCoroutine(Blast());
        }
    }

    private IEnumerator Blast()
    {
        _effector.enabled = true;
        yield return new WaitForSeconds(blastingTime);
        _effector.enabled = false;
    }
}
