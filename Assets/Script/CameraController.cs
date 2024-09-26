using UnityEngine;

public class CameraController : MonoBehaviour{

    public GameObject FollowTarget;
    private Vector3 targetPos;
    public float moveSpeed;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    void Start(){
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        // Initialiser les limites
        UpdateBounds();
    }

    void Update(){
        // Suivre la cible
        targetPos = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Appliquer les limites de la caméra
        ClampCamera();
    }

    // Fonction pour téléporter instantanément la caméra à la position du joueur
    public void TeleportToPlayer()
    {
        targetPos = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        
        // Téléporter la caméra à la position du joueur
        transform.position = targetPos;

        // Appliquer les limites de la caméra directement
        ClampCamera();
    }


    // Fonction pour mettre à jour les bounds lorsqu'ils changent
    public void UpdateBounds()
    {
        if (boundBox != null)
        {
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
            
            // Redéfinir les limites pour la caméra
            halfHeight = theCamera.orthographicSize;
            halfWidth = halfHeight * Screen.width / Screen.height;
        }
    }


    // Fonction pour clamer la position de la caméra aux limites
    private void ClampCamera()
    {
        if (boundBox != null)
        {
            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
