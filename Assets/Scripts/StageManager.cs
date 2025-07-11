using System;
using System.Collections.Generic;
using Interactables;
using Throws;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    [SerializeField] private GameObject cakePrefabs;
    [SerializeField] private List<GameObject> cakeThrowerList;
    [SerializeField] private List<GameObject> throwerList;
    [SerializeField] private List<GameObject> interactableList;
    [SerializeField] private GameObject failedZone;
    [SerializeField] private Camera zoom;

    public Thrower currentThrower;
    public Interactable currentInteractable;
    public Interactable cake;

    private int _currentStage;
    private int _currentCakeStage;
    public int _allStage;

    public int MaxStage { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MaxStage = cakeThrowerList.Count + throwerList.Count;
        
        cake = Instantiate(cakePrefabs).GetComponent<Interactable>();

        cake.gameObject.SetActive(false);

        StageStart();
    }

    public event Action OnStageStart;
    public event Action OnStageEnd;
    public event Action OnStageFailed;
    public event Action OnStageClear;
    public event Action OnNextStage;

    private bool IsCakeStage()
    {
        return _allStage % 2 == 0;
    }

    public void StageStart()
    {
        if (IsCakeStage())
        {
            cake.gameObject.SetActive(true);

            currentInteractable = cake;
            currentThrower = Instantiate(cakeThrowerList[_currentCakeStage]).GetComponent<Thrower>();
        }
        else
        {
            currentInteractable = Instantiate(interactableList[_currentStage]).GetComponent<Interactable>();
            currentThrower = Instantiate(throwerList[_currentStage]).GetComponent<Thrower>();
        }

        zoom.transform.localPosition = currentInteractable.transform.localPosition + Vector3.back;

        OnStageStart?.Invoke();
    }

    public void StageRestart()
    {
        if (IsCakeStage())
        {
            Destroy(currentThrower.gameObject);
            ((Cake)cake).Clear();
        }
        else
        {
            Destroy(currentThrower.gameObject);
            Destroy(currentInteractable.gameObject);
        }

        StageStart();
    }

    public void StageEnd()
    {
        OnStageEnd?.Invoke();

        if (IsCakeStage())
        {
            cake.gameObject.SetActive(false);

            _currentCakeStage++;
        }
        else
        {
            Destroy(currentInteractable.gameObject);
            
            _currentStage++;
        }

        _allStage++;
        
        Destroy(currentThrower.gameObject);
    }

    public void StageFailed()
    {
        OnStageFailed?.Invoke();

        StageRestart();
    }

    public void StageClear()
    {
        if (SoundManager.Instance) SoundManager.Instance.Play_R_SFX("sound_cheer_", 4);
        
        OnStageClear?.Invoke();
    }

    public void NextStage()
    {
        StageEnd();

        OnNextStage?.Invoke();

        StageStart();
    }

    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName)) SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}