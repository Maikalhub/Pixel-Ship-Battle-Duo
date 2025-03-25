using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	// Ссылка на аудиофайл
	public AudioClip backgroundMusic;

	// Ссылка на компонент AudioSource
	private AudioSource audioSource;

	// Статическая переменная для проверки существования единственного экземпляра MusicManager
	private static MusicManager instance;

	// Массив сцен, в которых должна играть музыка
	public string[] scenesWithMusic;

	void Awake()
	{
		// Если экземпляр MusicManager уже существует, уничтожаем этот объект
		if (instance != null)
		{
			Destroy(gameObject);  // Удаляем дублирующийся объект
		}
		else
		{
			// Иначе сохраняем этот объект
			instance = this;
		}
	}

	void Start()
	{
		// Получаем компонент AudioSource на объекте
		audioSource = GetComponent<AudioSource>();

		// Проверяем, нужно ли воспроизводить музыку на текущей сцене
		if (IsMusicScene(SceneManager.GetActiveScene().name))
		{
			PlayMusic();
		}
		else
		{
			StopMusic();
		}
	}

	// Метод, вызываемый каждый раз при загрузке новой сцены
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	// Обработчик события загрузки сцены
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		// Проверяем, нужно ли воспроизводить музыку в новой сцене
		if (IsMusicScene(scene.name))
		{
			PlayMusic();
		}
		else
		{
			StopMusic();
		}
	}

	// Функция для проверки, должна ли музыка играть в текущей сцене
	private bool IsMusicScene(string sceneName)
	{
		foreach (string scene in scenesWithMusic)
		{
			if (sceneName == scene)
			{
				return true;
			}
		}
		return false;
	}

	// Функция для начала воспроизведения музыки
	private void PlayMusic()
	{
		if (backgroundMusic != null && audioSource != null && !audioSource.isPlaying)
		{
			audioSource.clip = backgroundMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	// Функция для остановки музыки
	private void StopMusic()
	{
		if (audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	// Функция для изменения громкости музыки (по желанию)
	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
