using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TetrisManager : MonoBehaviour
{
    [SerializeField] private KeyCode newBlockKeyCode = KeyCode.N;
    [SerializeField] private GameObject prefabBlockI;
    [SerializeField] private Transform gridTransform;
    // [SerializeField] private Tilemap tilemap;

    private void Start() {
        // StartCoroutine(QuedaBlocos());
    }

    private void Update() {
        if (Input.GetKeyDown(newBlockKeyCode)) {
            Debug.Log("New Block");
            GameObject newBlock = Instantiate(prefabBlockI, gridTransform);
            Tilemap tilemap;
            if (newBlock.TryGetComponent<Tilemap>(out tilemap)) {
                Vector3Int gridPosition = tilemap.WorldToCell(newBlock.transform.position);
                Debug.Log(gridPosition);
            }
        }
    }

    // private IEnumerator QuedaBlocos()
    // {
    //     while (true)
    //     {
    //         // Instancie o bloco do prefab.
    //         GameObject novoBloco = Instantiate(prefabBlockI, gridTransform);

    //         // Ajuste a posição inicial do bloco para que ele comece acima da grade.
    //         novoBloco.transform.position = new Vector3(Random.Range(-gridTransform.localScale.x / 2f, grid.localScale.x / 2f),
    //                                                   grid.localScale.y,
    //                                                   0f);

    //         yield return new WaitForSeconds(intervaloQueda);
    //     }
    // }
}
