using UnityEngine;

public class Sprite_Hide : MonoBehaviour // �������� ���� �����
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
    }
}


