using System;
using UnityEngine;
using DG.Tweening;
public class BockSpawnAnimation : MonoBehaviour
{
    private void Awake()
    {
        transform.DOScale(new Vector3(1, 1, 1), 1f);
        transform.DOMove(transform.position + new Vector3(0, 2, 0), 1f);
    }
}
