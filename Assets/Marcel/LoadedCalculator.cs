using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedCalculator : MonoBehaviour
{
    public static LoadedCalculator Instance { get; private set; }
    
    private GameObject[] LoadedObjects;
    private Vector2 CalculatedSpaceshipDirection;
    private float CalculatedMassLeftSide;
    private float CalculatedMassRightSide;
    
    [SerializeField] private float SpaceshipWidth = 10.0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.LoadedObjects = GameObject.FindGameObjectsWithTag("Package");
        this.CalculatedSpaceshipDirection.y = 1.0f;
    }

    private void FixedUpdate()
    {
        CalculateDistribution();
        CalculateSpaceShipDirection();
    }
    
    private void CalculateDistribution()
    {
        foreach (GameObject package in this.LoadedObjects)
        {
            Vector2 packagePosition = package.transform.position;
            Vector2 spaceshipPosition = this.transform.position;
            
            Vector2 direction = packagePosition - spaceshipPosition;

            if (direction.x < 0.0f)
            {
                Rigidbody2D packageRigidbody = package.GetComponent<Rigidbody2D>();
                float packageMass = packageRigidbody.mass;
                float massCenterScale = direction.x / this.SpaceshipWidth;
                this.CalculatedMassLeftSide += (packageMass * massCenterScale);
            }
            else
            {
                Rigidbody2D packageRigidbody = package.GetComponent<Rigidbody2D>();
                float packageMass = packageRigidbody.mass;
                float massCenterScale = direction.x / this.SpaceshipWidth;
                this.CalculatedMassRightSide += (packageMass * massCenterScale);
            }
        }
    }

    private void CalculateSpaceShipDirection()
    {
        if (this.CalculatedMassLeftSide > this.CalculatedMassRightSide)
        {
            float difference = 0.0f;
            difference = this.CalculatedMassLeftSide / (this.CalculatedMassLeftSide + this.CalculatedMassRightSide);
            this.CalculatedSpaceshipDirection.x = -difference;                
        }
        
        if (this.CalculatedMassLeftSide < this.CalculatedMassRightSide)
        {
            float difference = 0.0f;
            difference = this.CalculatedMassRightSide / (this.CalculatedMassLeftSide + this.CalculatedMassRightSide);
            this.CalculatedSpaceshipDirection.x = difference;                
        }
    }
    
    public Vector2 GetCalculatedSpaceshipDirection()
    {
        return this.CalculatedSpaceshipDirection;
    }
}
