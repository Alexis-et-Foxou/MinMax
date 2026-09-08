using Pieces;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _blacktile;
    [SerializeField] private Tile _whitetile;

    private Tile[,] _tiles = new Tile[8, 8];

    private void Awake()
    {
        _tiles = new Tile[,]
        {
            { _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile },
            { _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile },
            { _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile },
            { _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile },
            { _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile },
            { _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile },
            { _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile },
            { _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile, _whitetile, _blacktile }
        };
    }

    private void Start()
    {
        Pawn pawn = new Pawn();
        createBoard();
    }

    private void createBoard()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                //Tile tile = _tiles[i, j];
                Tile tile = (i + j) % 2 == 0 ?  _blacktile : _whitetile;
                _tilemap.SetTile(new Vector3Int(i, j, 0), tile);
            }
        }
    }
}
