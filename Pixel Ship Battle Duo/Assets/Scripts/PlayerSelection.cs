using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSelection : MonoBehaviour
{
	private GameObject[] characters;  // Массив для хранения персонажей
	private int index;  // Индекс выбранного персонажа

	private void Start()
	{
		//
		index = PlayerPrefs.GetInt("SelectPlayer");
		// Инициализируем массив в зависимости от количества дочерних объектов
		characters = new GameObject[transform.childCount];

		// Если нет дочерних объектов, выводим ошибку и выходим из метода
		if (transform.childCount == 0)
		{
			Debug.LogError("Нет дочерних объектов для выбора персонажа!");
			return;
		}

		// Заполняем массив дочерними объектами
		for (int i = 0; i < transform.childCount; i++)
		{
			characters[i] = transform.GetChild(i).gameObject;
		}

		// Отключаем все объекты
		foreach (GameObject go in characters)
		{
			go.SetActive(false);
		}

		// Активируем первого персонажа, если массив не пустой
		if (characters.Length > 0)
		{
			characters[index].SetActive(true);
		}
	}

	// Метод для выбора персонажа влево
	public void SelectLeft()
	{
		if (characters.Length == 0) return;  // Проверка на пустой массив

		// Отключаем текущего персонажа
		characters[index].SetActive(false);

		// Уменьшаем индекс
		index--;

		// Если индекс стал меньше 0, возвращаем его к последнему элементу массива
		if (index < 0)
		{
			index = characters.Length - 1;
		}

		// Активируем нового персонажа
		characters[index].SetActive(true);
	}

	// Метод для выбора персонажа вправо
	public void SelectRight()
	{
		if (characters.Length == 0) return;  // Проверка на пустой массив

		// Отключаем текущего персонажа
		characters[index].SetActive(false);

		// Увеличиваем индекс
		index++;

		// Если индекс стал больше или равен длине массива, возвращаем его к первому элементу
		if (index >= characters.Length)
		{
			index = 0;
		}

		// Активируем нового персонажа
		characters[index].SetActive(true);
	}

	public void StartScene() 
	{
		PlayerPrefs.GetInt("SelectPlayer", index);
		SceneManager.LoadScene("Game");
	}
}
