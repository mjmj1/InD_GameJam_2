using Interactables;
using UnityEngine;

namespace Throwables
{
    public class Raisin : Throwable
    {
        [SerializeField] Sprite[] sprites;

        protected override void Awake()
        {
            base.Awake();
            Torque(200f);
            ThrowableSprite.sprite = sprites[Random.Range(0, sprites.Length)];
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Target"))
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;         // �̵� ����
                    rb.angularVelocity = 0f;            // ȸ�� ����
                }
            }
        }
    }
}