using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Candle : MonoBehaviour
{
    private bool isThrow;
    public bool IsThrow => isThrow;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ThrowCandle()
    {
        isThrow = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Cake"))
        {
            rb.velocity = Vector2.zero;         // �ӵ� ��� ����
            rb.angularVelocity = 0f;            // ȸ���� ����
            rb.isKinematic = true;              // ���� ���� �� �и���
            rb.gravityScale = 0f;               // �߷µ� ����
        }
    }
}
