using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
	// ������ �� ��������� (��������, ���), ������� ����� �������� �������
	public GameObject containerObject;

	// ������ ��������, ������� ����� ����������� � ����������
	public GameObject[] prefabs;

	// ����������� � ������������ ���������� �������� ��� ������� �������
	public int minCount = 1;
	public int maxCount = 10;

	void Start()
	{
		// �������� ������� ���������� (���� ��������� - ���, �� ��� ������� ����� � Transform.localScale)
		Vector3 containerSize = containerObject.transform.localScale;

		// ��� ������� ������� �������� ��������� ���������� ��������
		foreach (var prefab in prefabs)
		{
			// ���������� ��������� ���������� ����������� ��� ������� �������
			int objectCount = Random.Range(minCount, maxCount + 1);

			// ������� ��������� ���������� �������� ��� �������� �������
			for (int i = 0; i < objectCount; i++)
			{
				SpawnPrefab(prefab, containerSize);
			}
		}
	}

	void SpawnPrefab(GameObject prefab, Vector3 containerSize)
	{
		// �������� ������� ���������� (��� ����� ����� ����������)
		Vector3 containerPosition = containerObject.transform.position;

		// ���������� ��������� ������� ������ ���������� � ������ ��������
		Vector3 randomPosition = containerPosition + new Vector3(
			Random.Range(-containerSize.x / 2, containerSize.x / 2),
			Random.Range(-containerSize.y / 2, containerSize.y / 2),
			Random.Range(-containerSize.z / 2, containerSize.z / 2)
		);

		// ������� ������ � ��������� �������
		Instantiate(prefab, randomPosition, Quaternion.identity);
	}
}
