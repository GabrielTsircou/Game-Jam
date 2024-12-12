using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 10;
    public bool hasNoMass = true;
    // Update is called once per frame
    void Update()
    {
        Vector3 target = playerTransform.position;
        Vector3 calcTarget = Vector3.Lerp(transform.position, target, (moveSpeed + Time.deltaTime)/1000);
        transform.position = calcTarget;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}