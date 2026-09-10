using UnityEngine.Tilemaps;
using UnityEngine;
using System.Collections.Generic;

namespace Pieces
{
    public class Knight : Piece
    {
        public override Tile Tile => Color == PieceColor.White ? 
            GameManager.Instance.WhiteKnightTile : GameManager.Instance.BlackKnightTile;
        
        public Knight(PieceColor color) : base(color) { }
        
        public override List<Vector2Int> GetMovements(Piece[,] piece)
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            
            movements.Add(new Vector2Int(2, 1));
            movements.Add(new Vector2Int(2, -1));
            movements.Add(new Vector2Int(-2, 1));
            movements.Add(new Vector2Int(1, -2));
            movements.Add(new Vector2Int(1, 2));
            movements.Add(new Vector2Int(-1, 2));
            movements.Add(new Vector2Int(-2, -1));
            movements.Add(new Vector2Int(-1, -2));
            
            return movements;
        }
    }
}