using UnityEngine;

public class puzzleController : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public Transform[] targetPositions;
    private int emptyIndex;
    public GameObject door;

    private void Start()
    {
        // Initialize the puzzle by assigning the initial index of the empty slot
        emptyIndex = 6;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (emptyIndex - 3 >= 0)
            {
                SwapPieces(emptyIndex, emptyIndex - 3);
                emptyIndex -= 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (emptyIndex + 3 < puzzlePieces.Length)
            {
                SwapPieces(emptyIndex, emptyIndex + 3);
                emptyIndex += 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (emptyIndex % 3 != 0)
            {
                SwapPieces(emptyIndex, emptyIndex - 1);
                emptyIndex -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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

    public bool CheckCorrectOrder()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].transform.position != targetPositions[i].position)
            {
                // The puzzle is not in the correct order
                return false;
            }
        }
       return true;
        // Puzzle is in the correct order
        
    }
}