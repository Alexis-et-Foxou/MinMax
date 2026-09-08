using Pieces;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Header("Pieces Visual")]
    public Tile WhitePawnTile;
    public Tile WhiteRookTile;
    public Tile WhiteBishopTile;
    public Tile WhiteKnightTile;
    public Tile WhiteQueenTile;
    public Tile WhiteKingTile;
        
    public Tile BlackPawnTile;
    public Tile BlackRookTile;  
    public Tile BlackBishopTile;
    public Tile BlackKnightTile;
    public Tile BlackQueenTile;
    public Tile BlackKingTile;
    
    [Header("References")]
    [SerializeField] private int _size;
    [SerializeField] private Tilemap _pieceTilemap;
    [SerializeField] private Tilemap _boardTilemap;
    [SerializeField] private Tile _blacktile;
    [SerializeField] private Tile _whitetile;

    private Piece[,] _pieces = new Piece[8, 8];

    private void Awake()
    {
        _pieces = new Piece[,] { 
            { new Rook(PieceColor.Black), new Knight(PieceColor.Black), new Bishop(PieceColor.Black), new Queen(PieceColor.Black), new King(PieceColor.Black), new Bishop(PieceColor.Black), new Knight(PieceColor.Black), new Rook(PieceColor.Black)}, 
            { new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black)}, 
            { null, null, null, null, null, null, null, null}, 
            { null, null, null, null, null, null, null, null}, 
            { null, null, null, null, null, null, null, null}, 
            { null, null, null, null, null, null, null, null}, 
            { new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White)}, 
            { new Rook(PieceColor.White), new Knight(PieceColor.White), new Bishop(PieceColor.White), new Queen(PieceColor.White), new King(PieceColor.White), new Bishop(PieceColor.White), new Knight(PieceColor.White), new Rook(PieceColor.White)}
        };
    }

    private void Start()
    {
        CreateBoard();
        DisplayPieces();
    }

    private void CreateBoard()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                Tile tile = (i + j) % 2 == 0 ?  _blacktile : _whitetile;
                _boardTilemap.SetTile(new Vector3Int(i, j, 0), tile);
            }
        }
    }

    private void DisplayPieces()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                Piece piece = _pieces[i, j];
                if (piece != null)
                {
                    _pieceTilemap.SetTile(new Vector3Int(j, i, 0), piece.Tile);
                }
            }
        }
    }
}
