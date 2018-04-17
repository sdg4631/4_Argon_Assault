﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGate : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    // todo remove from inspector later
    [Range(0, 1)] [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved

    Vector3 startingPos; // must be stored for absolute movement

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
        Rotate();
    }

    private void Oscillate()
    {
        // protect against period = 0 with Epsilon, the smallest possible float closest to 0
        if (period <= Mathf.Epsilon) { return; }

        // set movement factor
        float cycles = Time.time / period; // grows continually from 0
        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1
        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward);       
    }

}
