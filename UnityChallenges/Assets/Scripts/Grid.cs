using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    int gridSize;
    float spacing;

    List<GameObject> currentGrid = new List<GameObject>();

    [SerializeField] Slider gridSizeSlider;
    [SerializeField] Slider spacingSlider;

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        ClearGrid();

        gridSize = (int) gridSizeSlider.value;
        spacing = spacingSlider.value;

        for (int row = 0; row < gridSize; row++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.position = new Vector3(spacing * column, 0f, spacing * row);

                cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

                currentGrid.Add(cube);
            }
        }
    }

    private void ClearGrid()
    {
        foreach (var obj in currentGrid)
        {
            Destroy(obj);
        }
    }
}
