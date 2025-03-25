using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	// ������ �� ���������
	public AudioClip backgroundMusic;

	// ������ �� ��������� AudioSource
	private AudioSource audioSource;

	// ����������� ���������� ��� �������� ������������� ������������� ���������� MusicManager
	private static MusicManager instance;

	// ������ ����, � ������� ������ ������ ������
	public string[] scenesWithMusic;

	void Awake()
	{
		// ���� ��������� MusicManager ��� ����������, ���������� ���� ������
		if (instance != null)
		{
			Destroy(gameObject);  // ������� ������������� ������
		}
		else
		{
			// ����� ��������� ���� ������
			instance = this;
		}
	}

	void Start()
	{
		// �������� ��������� AudioSource �� �������
		audioSource = GetComponent<AudioSource>();

		// ���������, ����� �� �������������� ������ �� ������� �����
		if (IsMusicScene(SceneManager.GetActiveScene().name))
		{
			PlayMusic();
		}
		else
		{
			StopMusic();
		}
	}

	// �����, ���������� ������ ��� ��� �������� ����� �����
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	// ���������� ������� �������� �����
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		// ���������, ����� �� �������������� ������ � ����� �����
		if (IsMusicScene(scene.name))
		{
			PlayMusic();
		}
		else
		{
			StopMusic();
		}
	}

	// ������� ��� ��������, ������ �� ������ ������ � ������� �����
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

	// ������� ��� ������ ��������������� ������
	private void PlayMusic()
	{
		if (backgroundMusic != null && audioSource != null && !audioSource.isPlaying)
		{
			audioSource.clip = backgroundMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	// ������� ��� ��������� ������
	private void StopMusic()
	{
		if (audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	// ������� ��� ��������� ��������� ������ (�� �������)
	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
