﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LoadingScript : MonoBehaviour
{
    public Slider slider;
    bool IsDone = false;
    float fTime = 0f;
    AsyncOperation async_operation;

    void Start()
    {
        StartCoroutine(StartLoad("GameScene"));
    }

    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 3)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = Application.LoadLevelAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return true;
            }
        }
    }
}