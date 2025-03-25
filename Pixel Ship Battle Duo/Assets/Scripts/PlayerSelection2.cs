using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSelection2 : MonoBehaviour
{
	private GameObject[] characters;  // ������ ��� �������� ����������
	private int index;  // ������ ���������� ���������

	private void Start()
	{
		// �������������� ������ � ����������� �� ���������� �������� ��������
		characters = new GameObject[transform.childCount];

		// ���� ��� �������� ��������, ������� ������ � ������� �� ������
		if (transform.childCount == 0)
		{
			Debug.LogError("��� �������� �������� ��� ������ ���������!");
			return;
		}

		// ��������� ������ ��������� ���������
		for (int i = 0; i < transform.childCount; i++)
		{
			characters[i] = transform.GetChild(i).gameObject;
		}

		// ��������� ��� �������
		foreach (GameObject go in characters)
		{
			go.SetActive(false);
		}

		// ���������� ������� ���������, ���� ������ �� ������
		if (characters.Length > 0)
		{
			characters[0].SetActive(true);
			index = 0;  // ��������� ������ � ������ ��������
		}
	}

	// ����� ��� ������ ��������� �����
	public void SelectLeft()
	{
		if (characters.Length == 0) return;  // �������� �� ������ ������

		// ��������� �������� ���������
		characters[index].SetActive(false);

		// ��������� ������
		index--;

		// ���� ������ ���� ������ 0, ���������� ��� � ���������� �������� �������
		if (index < 0)
		{
			index = characters.Length - 1;
		}

		// ���������� ������ ���������
		characters[index].SetActive(true);
	}

	// ����� ��� ������ ��������� ������
	public void SelectRight()
	{
		if (characters.Length == 0) return;  // �������� �� ������ ������

		// ��������� �������� ���������
		characters[index].SetActive(false);

		// ����������� ������
		index++;

		// ���� ������ ���� ������ ��� ����� ����� �������, ���������� ��� � ������� ��������
		if (index >= characters.Length)
		{
			index = 0;
		}

		// ���������� ������ ���������
		characters[index].SetActive(true);
	}
}
