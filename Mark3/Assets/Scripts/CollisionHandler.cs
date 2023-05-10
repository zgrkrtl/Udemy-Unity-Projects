using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    Movement mv;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    bool isTransitioning;
    bool collisionDisabled = false;
    AudioSource asrc;
    private void Start()
    {
        asrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Debug key: L");
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Debug key: C");
            collisionDisabled = !collisionDisabled; //toggle boolean variable
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (collisionDisabled) { return; }
        if (!isTransitioning)
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Friendly");
                    break;
                case "Finish":
                    StartSuccessSeq();
                    break;
                default:
                    StartCrashSeq();
                    break;
            }
        }

    }

    void StartSuccessSeq()
    {
        isTransitioning = true;
        asrc.Stop();
        asrc.PlayOneShot(success);
        successParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSeq()
    {
        isTransitioning = true;
        asrc.Stop();
        asrc.PlayOneShot(crash);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);

    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
