using UnityEngine;

public class Match_fire : MonoBehaviour
{
	public Sprite[] fireSprites;        // �Ҳ� �ִϸ��̼ǿ� ��������Ʈ �迭
	public float changeInterval = 0.25f; // ���� ���� (��)

	private SpriteRenderer spriteRenderer;
	private float timer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (fireSprites.Length > 0)
		{
			spriteRenderer.sprite = fireSprites[Random.Range(0, fireSprites.Length)];
		}
	}

	void Update()
	{
		spriteRenderer.sprite = fireSprites[Random.Range(0, fireSprites.Length)];
		timer += Time.deltaTime;
	}
}
