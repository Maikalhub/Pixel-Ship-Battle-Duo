using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
	// Ссылка на контейнер (например, куб), который будет задавать границы
	public GameObject containerObject;

	// Массив префабов, которые будут размещаться в контейнере
	public GameObject[] prefabs;

	// Минимальное и максимальное количество объектов для каждого префаба
	public int minCount = 1;
	public int maxCount = 10;

	void Start()
	{
		// Получаем размеры контейнера (если контейнер - куб, то его размеры будут в Transform.localScale)
		Vector3 containerSize = containerObject.transform.localScale;

		// Для каждого префаба выбираем случайное количество объектов
		foreach (var prefab in prefabs)
		{
			// Генерируем случайное количество экземпляров для каждого префаба
			int objectCount = Random.Range(minCount, maxCount + 1);

			// Создаем случайное количество объектов для текущего префаба
			for (int i = 0; i < objectCount; i++)
			{
				SpawnPrefab(prefab, containerSize);
			}
		}
	}

	void SpawnPrefab(GameObject prefab, Vector3 containerSize)
	{
		// Получаем позицию контейнера (где будет центр контейнера)
		Vector3 containerPosition = containerObject.transform.position;

		// Генерируем случайную позицию внутри контейнера с учетом размеров
		Vector3 randomPosition = containerPosition + new Vector3(
			Random.Range(-containerSize.x / 2, containerSize.x / 2),
			Random.Range(-containerSize.y / 2, containerSize.y / 2),
			Random.Range(-containerSize.z / 2, containerSize.z / 2)
		);

		// Создаем объект в случайной позиции
		Instantiate(prefab, randomPosition, Quaternion.identity);
	}
}
