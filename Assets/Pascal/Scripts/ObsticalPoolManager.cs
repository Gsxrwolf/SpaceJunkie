using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalPoolManager : MonoBehaviour
{
    public static ObsticalPoolManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance is not null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    System.Random rnd = new System.Random();

    [SerializeField] private List<GameObject> ufos = new List<GameObject>();
    private int indexPointerUfos = 0;
    [SerializeField] private List<GameObject> rocks = new List<GameObject>();
    private int indexPointerRocks = 0;
    [SerializeField] private List<GameObject> powerups = new List<GameObject>();
    private int indexPointerPowerups = 0;
    [SerializeField] private Vector2 hiddenPoolPoint;
    [SerializeField] private GameObject plane;
    [SerializeField] private int spawnXRange;
    [SerializeField] private int spawnYOffset;

    private int frameCounterUfos;
    private int framesUntillSpawnUfos;

    private int frameCounterRocks;
    private int framesUntillSpawnRocks;

    private int frameCounterPowerups;
    private int framesUntillSpawnPowerups;

    
    private void Start()
    {
        foreach (GameObject rock in rocks)
        {
            MoveToHiddenPoint(rock);
        }
        foreach (GameObject ufo in ufos)
        {
            MoveToHiddenPoint(ufo);
        }
        foreach (GameObject powerup in powerups)
        {
            MoveToHiddenPoint(powerup);
        }

        framesUntillSpawnUfos = rnd.Next(2 * 5, 5 * 5);
        framesUntillSpawnRocks = rnd.Next(2 * 5, 4 * 5);
        framesUntillSpawnPowerups = rnd.Next(3 * 5, 5 * 5);
    }

    private void FixedUpdate()
    {
        #region Ufos
        if (frameCounterUfos < framesUntillSpawnUfos)
        {
            frameCounterUfos++;
        }
        else
        {
            frameCounterUfos = 0;
            framesUntillSpawnUfos = rnd.Next(10 * 5, 15 * 5);

            MoveToSpawnPoint(ufos[indexPointerUfos]);
            indexPointerUfos++;
            if (indexPointerUfos > ufos.Count - 1)
            {
                indexPointerUfos = 0;
            }
        }
        #endregion

        #region Rocks
        if (frameCounterRocks < framesUntillSpawnRocks)
        {
            frameCounterRocks++;
        }
        else
        {
            frameCounterRocks = 0;
            framesUntillSpawnRocks = rnd.Next(9 * 5, 11 * 5);

            MoveToSpawnPoint(rocks[indexPointerRocks]);
            indexPointerRocks++;
            if (indexPointerRocks > rocks.Count - 1)
            {
                indexPointerRocks = 0;
            }
        }
        #endregion

        #region Powerups
        if (frameCounterPowerups < framesUntillSpawnPowerups)
        {
            frameCounterPowerups++;
        }
        else
        {
            frameCounterPowerups = 0;
            framesUntillSpawnPowerups = rnd.Next(13 * 5, 18 * 5);


            MoveToSpawnPoint(powerups[indexPointerPowerups]);
            indexPointerPowerups++;
            if(indexPointerPowerups > powerups.Count-1)
            {
                indexPointerPowerups = 0;
            }
        }
        #endregion
    }

    public void MoveToHiddenPoint(GameObject _gameobj)
    {
        _gameobj.transform.position = hiddenPoolPoint;
        _gameobj.SetActive(false);
    }
    public void MoveToSpawnPoint(GameObject _gameobj)
    {
        Vector2 planePos = plane.transform.position;

        float randomXPos = rnd.Next((int)(planePos.x - spawnXRange), (int)(planePos.x + spawnXRange));

        Vector2 spawnPoint = new Vector2(randomXPos, planePos.y + spawnYOffset);

        _gameobj.SetActive(true);
        _gameobj.transform.position = spawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       MoveToHiddenPoint(collision.gameObject);
    }
}
