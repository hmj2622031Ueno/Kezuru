using UnityEngine;
using UnityEngine.InputSystem;

public class WoodController : MonoBehaviour
{
	private Vector3 startPosition;	// 木の初期位置
	private Vector3 startScale; // 木の初期サイズ
	private float shavedLength = 0f;    // 木の削れた長さ
	[SerializeField] private float shaveSpeed = 0.1f;
	[SerializeField] private int lengthAxis = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		startPosition = transform.position;
		startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current == null) { return; }

		
    }
}
