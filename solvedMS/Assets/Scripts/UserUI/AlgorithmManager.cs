using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmManager : MonoBehaviour
{
    public int AlgorithmSort { get; private set; }

    private void Awake()
    {
        AlgorithmSort = 0;
    }
    public void SetAlgorithm(int id)
    {
        AlgorithmSort ^= id;
    }
}
