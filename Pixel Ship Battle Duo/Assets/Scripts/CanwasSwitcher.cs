using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
	// Ссылки на оба канваса
	public GameObject canvas1;
	public GameObject canvas2;

	// Функция для перехода между канвасами
	public void SwitchCanvas()
	{
		// Если Canvas1 активен, скрыть его и показать Canvas2
		if (canvas1.activeSelf)
		{
			canvas1.SetActive(false);
			canvas2.SetActive(true);
		}
		// Если Canvas2 активен, скрыть его и показать Canvas1
		else if (canvas2.activeSelf)
		{
			canvas2.SetActive(false);
			canvas1.SetActive(true);
		}
	}
}
