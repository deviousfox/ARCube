using System;
using UnityEngine;

namespace ARCubeBlock
{
    public class BlockComponent : MonoBehaviour
    {
        public static Action<int> OnCubeCollect;
        [Range(0, 10)] [SerializeField] private int rewardAmount;

        public void Collect()
        {
            OnCubeCollect?.Invoke(rewardAmount);

            Destroy(gameObject);
        }
    }
}