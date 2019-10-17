﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public int health = 100;
    public float hunger = 10;
    public float mating_desire = 0;
    public float speed = 10;
    public float bmr = 1;

    //How far an animal can see.
    public int sightRadius = 10;

    //Threshold at which animal will seek food.
    public float hungerThreshold = 7;


    //Threshold at which animal will seek a mate.
    public float matingThreshold = 5;

    public enum behaviours
    {
        random = 0,
        feeding = 1,
        mating = 2,
    }

    public enum genders
    {
        male=0,
        female=1
    }

    //Random by default
    public behaviours behaviour = behaviours.random;
    public genders gender = genders.female;

    //The point we are currently navigating too.
    public Vector3 objective = new Vector3(0, 0, 0);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        We need to determine what behaviour we are going with.
        We default to random wandering about. If we hit any thresholds we
        switch to that behaviour unit its done.
        */

        //If we have a random behaviour run an analysis to determine if we should switch.
        if(behaviour == behaviours.random)
        {

        }

        if(behaviour == behaviours.mating)
        {

        }

        if(behaviour == behaviours.feeding)
        {

        }


    }

    //We select a random point with x units and go there.
    void random()
    {

    }

    //We find the nearest food and eat it.
    void feeding()
    {

    }

    //We find the nearest neighbor of the same species and opposite gender and mate with it.
    void mating()
    {

    }

    //Reproduce.
    void mate()
    {

    }

    //Find new coordinates to go to.
    void getNewObjective()
    {

    }

    //Go to our objective coordinates.
    void goToObjective()
    {
        //Firstly we always star .1 above the ground.

    }
}