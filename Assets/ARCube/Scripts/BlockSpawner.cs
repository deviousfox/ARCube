using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace ARCubeBlock
{
    [RequireComponent(typeof(BlockFabric))]
    public class BlockSpawner : MonoBehaviour
    {
        //I didn’t fully understand how exactly the spawning of new objects was supposed to work,
        //so it’s done like this
        [SerializeField] private List<BlockComponent> blockField;
        [SerializeField] private BlockFabric blockFabric;
        [SerializeField] private Vector3Int fieldSize;
        [SerializeField] private int hollowInCenterFieldSize;
        [SerializeField] private float spawnBlockDelay = 1f;
        private WaitForSeconds spawnTimer;
        private bool IsCenterField(int xPos, int zPos)
        {
            return (xPos <= fieldSize.x / 2 - hollowInCenterFieldSize / 2
                    || xPos >= fieldSize.x / 2 + hollowInCenterFieldSize / 2)
                   && (zPos <= fieldSize.y / 2 - hollowInCenterFieldSize / 2
                       || zPos >= fieldSize.y / 2 + hollowInCenterFieldSize / 2);
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 randPosition = new Vector3(Random.Range(-fieldSize.x, fieldSize.x),
                Random.Range(1, fieldSize.y),
                Random.Range(-fieldSize.z, fieldSize.z));
            if (IsCenterField((int)randPosition.x, (int)randPosition.z))
            {
                return randPosition;
            }
            else
            {
                return GetRandomPosition();
            }
        }

        private void Awake()
        {
            blockFabric ??= GetComponent<BlockFabric>();
            blockField = new List<BlockComponent>();
            spawnTimer = new WaitForSeconds(spawnBlockDelay);
        }

        public void StartFillField()
        {
            StartCoroutine(SpawnBlock());

        }

        public void ResetFillField()
        {
            StopAllCoroutines();
            for (int i = 0; i < blockField.Count; i++)
            {
                if (blockField[i] != null)
                {
                    Destroy(blockField[i].gameObject);
                }
            }
            blockField.Clear();
            StartCoroutine(SpawnBlock());
        }

        private IEnumerator SpawnBlock()
        {
            while (true)
            {
               blockField.Add( blockFabric.GetNewRandomBlock(GetRandomPosition()));
                yield return spawnTimer;
            }
        }

    }
}