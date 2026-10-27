using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float maxDistance = 3.0f;	// 引きの最大距離
	[SerializeField] private float zoomSpeed = 2.0f;	// 引く速さ
	private Vector3 startPosition;  // カメラの初期位置
	private float currentDistance = 0f;	// どれだけ引いたか

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 開始時のカメラの位置を基準にする
		startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		float scroll = Mouse.current.scroll.ReadValue().y;  // マウスホイールの回転の取得
		currentDistance -= scroll * zoomSpeed;	// ホイール操作に応じた引く距離の変更
		currentDistance = Mathf.Clamp(currentDistance, 0f, maxDistance);    // カメラの移動距離の制限
		transform.position = startPosition - transform.forward * currentDistance;
    }
}
