﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zucchini : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);    
    }
}
