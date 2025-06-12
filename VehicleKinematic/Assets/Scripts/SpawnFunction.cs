using Meta.XR.MRUtilityKit;
using UnityEngine;

public class SpawnFunction : MonoBehaviour
{
    private MRUKRoom MRUKRoom;
    public GameObject GameObjectPrefab;
    public float SpawnHeight = 1f; // Height above the floor anchor

    public void InstanciateGame()
    {
        if (MRUKRoom == null)
        {
            Debug.Log("Game Started");
            MRUKRoom = MRUK.Instance.GetCurrentRoom();
            Vector3 gameAnchorPosition =
                MRUKRoom.FloorAnchor.GetAnchorCenter() + Vector3.up * SpawnHeight;
            GameObjectPrefab.transform.localPosition = gameAnchorPosition;
            GameObjectPrefab.gameObject.SetActive(true);
        }
    }
}