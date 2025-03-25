using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
	// ������ �� ��� �������
	public GameObject canvas1;
	public GameObject canvas2;

	// ������� ��� �������� ����� ���������
	public void SwitchCanvas()
	{
		// ���� Canvas1 �������, ������ ��� � �������� Canvas2
		if (canvas1.activeSelf)
		{
			canvas1.SetActive(false);
			canvas2.SetActive(true);
		}
		// ���� Canvas2 �������, ������ ��� � �������� Canvas1
		else if (canvas2.activeSelf)
		{
			canvas2.SetActive(false);
			canvas1.SetActive(true);
		}
	}
}
