using UnityEngine;
using UnityEngine.Tilemaps;

public class TeleportationTilemap : MonoBehaviour
{
    public Tilemap tilemap;

    // Coordonnées et bounds pour plusieurs téléporteurs
    [System.Serializable]
    public struct Teleporter
    {
        public Vector3Int[] teleportTilesCoords;  // Coordonnées des tuiles pour déclencher la téléportation
        public Vector3 teleportPosition;          // Position de téléportation
        public BoxCollider2D newBounds;           // Nouvelles limites de caméra après la téléportation
    }

    public Teleporter[] teleporters;  // Liste des téléporteurs

    private void Update()
    {
        Vector3Int playerTileCoords = tilemap.WorldToCell(transform.position);

        foreach (Teleporter teleporter in teleporters)
        {
            foreach (Vector3Int tileCoords in teleporter.teleportTilesCoords)
            {
                if (playerTileCoords == tileCoords)
                {
                    // Téléporter le joueur à la nouvelle position
                    transform.position = new Vector3(teleporter.teleportPosition.x, teleporter.teleportPosition.y, 0f);

                    // Vérifier la position du joueur après la téléportation
                    Debug.Log("Player téléporté à: " + transform.position);

                    // Mettre à jour les nouvelles limites de la caméra
                    CameraController cameraController = Camera.main.GetComponent<CameraController>();
                    cameraController.boundBox = teleporter.newBounds;
                    cameraController.UpdateBounds();

                    // Téléporter la caméra aussi
                    cameraController.TeleportToPlayer();

                    // Vérifier la position de la caméra après la mise à jour des bounds
                    Debug.Log("Position de la caméra après téléportation: " + Camera.main.transform.position);

                    return; // On sort du foreach pour éviter de vérifier d'autres téléporteurs
                }
            }
        }
    }
}
