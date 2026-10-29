using UnityEngine;
using UnityEngine.InputSystem;

public class FileController : MonoBehaviour
{
	private Vector3 startPosition;  // ヤスリの初期位置
	private Camera mainCamera;  // マウスの位置を取得するカメラ
	public bool isTouchWood = false;
	//FileController fileController;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        startPosition = transform.position;	// ゲーム開始時のヤスリの初期位置
		mainCamera = Camera.main;	// メインカメラの取得
    }

    // Update is called once per frame
    void Update()
    {
		if(Mouse.current == null || mainCamera == null) { return; }

		Vector2 mousePosition = Mouse.current.position.ReadValue();	// マウスの画面座標取得

		//ヤスリの初期位置までのカメラからの距離を取得する
		float distance = Vector3.Distance(mainCamera.transform.position, startPosition);

		// マウスの画面座標を3D空間の位置に変換する
		Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));

		transform.position = new Vector3(startPosition.x, startPosition.y, worldPosition.z);	// z軸のみ変更
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Wood")) { isTouchWood = true;}
	}

	private void OnTrigerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Wood")) { isTouchWood = false; }
	}
}
