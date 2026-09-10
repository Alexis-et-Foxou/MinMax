using System;
using System.Collections.Generic;
using System.Numerics;
using Pieces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using Vector3 = UnityEngine.Vector3;

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
    [SerializeField] private Tilemap _interactiveTilemap;
    [SerializeField] private Tilemap _overlayTilemap;
    [SerializeField] private Tile _redMouvementTile;
    [SerializeField] private Tile _selectedTile;
    [SerializeField] private Tile _blacktile;
    [SerializeField] private Tile _whitetile;

    private Grid _grid;
    private Piece[,] _pieces = new Piece[8, 8];
    private Vector3Int _prevMousePos = new Vector3Int(8,8,0);
    private Vector3Int _caseSelectedPos = new Vector3Int(8,8,0);
    private Vector3Int _mousePos;

    private void Awake()
    {
        _pieces = new Piece[,] { 
            { new Rook(PieceColor.White), new Knight(PieceColor.White), new Bishop(PieceColor.White), new King(PieceColor.White), new Queen(PieceColor.White), new Bishop(PieceColor.White), new Knight(PieceColor.White), new Rook(PieceColor.White)},
            { new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White), null, new Pawn(PieceColor.White), new Pawn(PieceColor.White), new Pawn(PieceColor.White)}, 
            { null, null, null, null, new Pawn(PieceColor.White), null, null, null}, 
            { null, null, null, null, null, null, null, null}, 
            { null, null, null, null, null, null, null, null}, 
            { null, null, null, null, null, null, null, null}, 
            { new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black), new Pawn(PieceColor.Black)},
            { new Rook(PieceColor.Black), new Knight(PieceColor.Black), new Bishop(PieceColor.Black),new King(PieceColor.Black), new Queen(PieceColor.Black), new Bishop(PieceColor.Black), new Knight(PieceColor.Black), new Rook(PieceColor.Black)}, 
        };

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (_pieces[i,j] == null) continue;
                _pieces[i, j]. Position = new Vector2Int(i, j);
            }
        }
    }

    private void Start()
    {
        _grid = gameObject.GetComponent<Grid>();
        CreateBoard();
        DisplayPieces();
    }
    
    private void Update()
    {
        _mousePos = GetMousePosition();
        if (!_mousePos.Equals(_prevMousePos))
        {
            _overlayTilemap.SetTile(_prevMousePos, null);
            Drawn(_mousePos, _selectedTile);
            _prevMousePos = _mousePos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            _caseSelectedPos = _mousePos;
            ClearInteractiveTilemap();
            if (_pieces[_caseSelectedPos.y, _caseSelectedPos.x] != null)
            {
                Debug.Log(_pieces[_caseSelectedPos.y, _caseSelectedPos.x].GetMovements(_pieces).Count);
                //List<Vector2Int> mouv = _pieces[_caseSelectedPos.y, _caseSelectedPos.x].GetMovements(_pieces);

                
                // for (int i = 0; i < mouv.Count; i++)
                // {
                //     Drawn(new Vector3Int(mouv[i].x, mouv[i].y), _redMouvementTile);
                // }
            }
        }
    }

    private void Drawn(Vector3Int position, Tile tile)
    {
        if (position.x < 8 && position.x >= 0 && position.y < 8 && position.y >= 0)
        {
            if (tile == _selectedTile) _overlayTilemap.SetTile(position, tile);
            else _interactiveTilemap.SetTile(position, tile);
        }
    }

    private void ClearInteractiveTilemap()
    {
        _interactiveTilemap.ClearAllTiles();
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

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return _grid.WorldToCell(mouseWorldPos);
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
