using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    public class Bishop : Piece
    {
        public override Tile Tile => Color == PieceColor.White ? 
            GameManager.Instance.WhiteBishopTile : GameManager.Instance.BlackBishopTile;
        
        public Bishop(PieceColor color) : base(color) { }
        public override List<Vector2Int> GetMovements(Piece[,] piece)
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(i, i));
            }
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(i, -i));
            }
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(-i, i));
            }
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(-i, -i));
            }
        
            return movements;
        }
    }
}