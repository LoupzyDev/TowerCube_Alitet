using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public static SpawnGenerator _instance;
    [SerializeField] private List<Vector3> spawns;
    [SerializeField] private List<Texture2D> texturesCube;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Material cubeMaterial;
    [SerializeField] private float reduceScale;
    private float currentScale = 1f;
    public int score;
    [SerializeField] private TextMeshProUGUI textScore;
    private void Start()
    {
        _instance = this;
        score = 0;
        spawnCube();
    }

    public void UpdateScore() {
        score++;
        textScore.text = score.ToString("D2");
    }

    public void spawnCube() {
        int randomIndex = Random.Range(0, spawns.Count);

        GameObject newCube = Instantiate(cubePrefab, spawns[randomIndex], Quaternion.identity);
        newCube.transform.localScale = newCube.transform.localScale * currentScale;

        currentScale *= reduceScale;

        newCube.GetComponent<Renderer>().material = RandomTexture();
    }
    Material RandomTexture()
    {
        int randomTextureIndex = Random.Range(0, texturesCube.Count);
        Material cubeInstanceMaterial = new Material(cubeMaterial);
        cubeInstanceMaterial.SetTexture("_MainTexture", texturesCube[randomTextureIndex]);
        return cubeInstanceMaterial;
    }
}
    