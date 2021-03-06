﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSorterObject : MonoBehaviour
{
    [SerializeField] private int sortingOrderBase = 1000;
    [SerializeField] private int offset = 0;
    [SerializeField] private bool runOnlyOnce = false;
    [SerializeField] private Transform orderTransform;

    private float timer;
    private float timerMax = 0.1f;
    private int sortingOrder;
    private SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            timer = timerMax;
            sortingOrder = (int)(sortingOrderBase - (orderTransform.position.y * 100) - offset);

            if (sortingOrder >= 0) render.sortingOrder = sortingOrder;

            if (runOnlyOnce) Destroy(this);
        }
    }
}
