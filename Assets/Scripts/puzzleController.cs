using UnityEngine;

public class puzzleController : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public Transform[] targetPositions;
    private int emptyIndex;

    private void Start()
    {
        // Initialize the puzzle by assigning the initial index of the empty slot
        emptyIndex = 6;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (emptyIndex - 3 >= 0)
            {
                SwapPieces(emptyIndex, emptyIndex - 3);
                emptyIndex -= 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (emptyIndex + 3 < puzzlePieces.Length)
            {
                SwapPieces(emptyIndex, emptyIndex + 3);
                emptyIndex += 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (emptyIndex % 3 != 0)
            {
                SwapPieces(emptyIndex, emptyIndex - 1);
                emptyIndex -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if ((emptyIndex + 1) % 3 != 0)
            {
                SwapPieces(emptyIndex, emptyIndex + 1);
                emptyIndex += 1;
            }
        }

       CheckCorrectOrder();
    }

    private void SwapPieces(int index1, int index2)
    {
        // Swap the positions of the puzzle pieces in the array
        Vector3 tempPos = puzzlePieces[index1].transform.position;
        puzzlePieces[index1].transform.position = puzzlePieces[index2].transform.position;
        puzzlePieces[index2].transform.position = tempPos;

        // Swap the puzzle pieces in the array
        GameObject tempPiece = puzzlePieces[index1];
        puzzlePieces[index1] = puzzlePieces[index2];
        puzzlePieces[index2] = tempPiece;
    }

    private void CheckCorrectOrder()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].transform.position != targetPositions[i].position)
            {
                // The puzzle is not in the correct order
                return;
            }
        }

        // Puzzle is in the correct order
        Debug.Log("Puzzle solved!");
    }
}