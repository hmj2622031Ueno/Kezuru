using UnityEngine;
using UnityEngine.InputSystem;

public class WoodController : MonoBehaviour
{
	private Vector3 startPosition;	// 木の初期位置
	private Vector3 startScale; // 木の初期サイズ
	public float InitialLength { get; private set; }
	private float lengthMultiplier;
	private float shavedLength = 0f;    // 木の削れた長さ
	[SerializeField] private float shaveSpeed = 0.1f;
	[SerializeField] private int lengthAxis = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		startPosition = transform.localPosition;
		startScale = transform.localScale;
		InitialLength = GetComponent<Renderer>().bounds.size.z;
		lengthMultiplier = 12.0f / InitialLength;
	}

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current == null) { return; }

		bool isLeftButtonPressed = Mouse.current.leftButton.isPressed;  // マウスの左長押しされているか

		Vector2 mouseDelta = Mouse.current.delta.ReadValue();   // マウス移動量の取得


		FileController fileController = FindFirstObjectByType<FileController>();
		// マウス左ボタンを長押ししながら動かしたときだけ削る
		if (isLeftButtonPressed && fileController != null && fileController.isTouchWood)
		{
			shavedLength += shaveSpeed * Time.deltaTime;
			shavedLength = Mathf.Min(shavedLength, startScale[lengthAxis]);

			// 木材の長さを短くする
			Vector3 newScale = startScale;
			newScale[lengthAxis] = startScale[lengthAxis] - shavedLength;
			transform.localScale = newScale;

			Vector3 newPosition = startPosition;
			newPosition.z = startPosition.z + shavedLength * 0.5f;
			transform.localPosition = newPosition;
		}
    }
}
