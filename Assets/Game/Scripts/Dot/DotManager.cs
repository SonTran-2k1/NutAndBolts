using Controller;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    public DotController dotController;

    void Update()
    {
        CheckDotMerge();
    }

    #region Check dot when merge circle

    private void CheckDotMerge()
    {
        if (dotController.DotCollider != null)
        {
            if (IsColliderInside(dotController.myDotCollider, dotController.DotCollider))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("inside the big collider.");
                }
            }
            else
            {
                Debug.Log("is not completely inside the big collider.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dotController.DotCollider = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dotController.DotCollider = null;
    }

    bool IsColliderInside(Collider2D big, Collider2D small)
    {
        Bounds bigBounds = big.bounds;
        Bounds smallBounds = small.bounds;

        // Kiểm tra các điểm biên của smallBounds
        Vector3[] corners = new Vector3[4];
        corners[0] = new Vector3(smallBounds.min.x, smallBounds.min.y);
        corners[1] = new Vector3(smallBounds.min.x, smallBounds.max.y);
        corners[2] = new Vector3(smallBounds.max.x, smallBounds.min.y);
        corners[3] = new Vector3(smallBounds.max.x, smallBounds.max.y);

        foreach (Vector3 corner in corners)
        {
            if (!bigBounds.Contains(corner))
            {
                return false;
            }
        }

        return true;
    }

    #endregion

    private void OnMouseDown()
    {
        if (GameManager.Instance.gameController.nailCurrent != null)
        {
            GameManager.Instance.gameController.nailCurrent.MoveToDestination(transform.position);
            dotController.stateDot = StateDot.Have;
        }
    }
}
