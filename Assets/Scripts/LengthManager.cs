using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.Hierarchy;
using UnityEditor.ShaderGraph.Internal;

public class LengthManager : MonoBehaviour
{
	[SerializeField] private TMP_Text targetLengthText;
	[SerializeField] private GameObject resultPanel;
	[SerializeField] private Transform wood;
	[SerializeField] private TMP_Text remainingResultText;
	private float targetLength;
	private float remainingLength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		targetLength = Random.Range(3.0f, 10.1f);
		targetLength = Mathf.Round(targetLength * 10f) / 10f;

		targetLengthText.text = "TargetLength : " + targetLength.ToString("F1") + "m";

		resultPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
		{
			float currentLength = wood.GetComponent<Renderer>().bounds.size.z;

			float initialLength = wood.GetComponent<WoodController>().InitialLength;
			remainingLength = currentLength * (12.0f / initialLength);

			remainingResultText.text = "RemainingLength : " + remainingLength.ToString("F1") + "m";

			resultPanel.SetActive(true);
		}
    }
}
