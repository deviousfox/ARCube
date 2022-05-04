using ARCubeBlock;
using UnityEngine;

namespace ARCubeBlock
{
    public class BlockFabric : MonoBehaviour
    {
        [SerializeField] private SpawnedBlockData[] availableBlocks;
        private float sumSpawnWeights;

        private void Awake()
        {
            foreach (var block in availableBlocks)
            {
                if (block != null)
                    sumSpawnWeights += block.SpawnRarity;
            }
        }

        public BlockComponent GetNewRandomBlock(Vector3 spawnPosition)
        {
            float randomWeight = Random.Range(10, sumSpawnWeights);
            float currentWeight = 0;
            foreach (var block in availableBlocks)
            {
                if (block == null || block.SpawnedBlock == null) continue;
                currentWeight += block.SpawnRarity;
                if (currentWeight >= randomWeight)
                {
                    return Instantiate(block.SpawnedBlock, spawnPosition, Quaternion.identity);
                }
            }

            return GetNewRandomBlock(spawnPosition);
        }
    }
}

[System.Serializable]
public class SpawnedBlockData
{
    [SerializeField] private float spawnRarity;
    [SerializeField] private BlockComponent spawnedBlock;

    public float SpawnRarity => spawnRarity;
    public BlockComponent SpawnedBlock => spawnedBlock;
}