using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    [SerializeField] private List<Vector3> spawns;
    [SerializeField] private List<Texture2D> texturesCube;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Material cubeMaterial;
    [SerializeField] private float reduceScale;
    private float currentScale = 1f;

    private void Start()
    {
        StartCoroutine(SpawnCube());
    }
    private IEnumerator SpawnCube()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            int randomIndex = Random.Range(0, spawns.Count);
            
            GameObject newCube = Instantiate(cubePrefab, spawns[randomIndex], Quaternion.identity);
            newCube.transform.localScale = newCube.transform.localScale * currentScale;

            currentScale *= reduceScale;

            newCube.GetComponent<Renderer>().material = RandomTexture();
        }
    }
    Material RandomTexture()
    {
        int randomTextureIndex = Random.Range(0, texturesCube.Count);
        Material cubeInstanceMaterial = new Material(cubeMaterial);
        cubeInstanceMaterial.SetTexture("_MainTexture", texturesCube[randomTextureIndex]);
        return cubeInstanceMaterial;
    }
}
    