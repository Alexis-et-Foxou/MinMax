using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Pieces
{
    public class Pawn : Piece
    {
        public override Tile Tile => Color == PieceColor.White ? 
            GameManager.Instance.WhitePawnTile : GameManager.Instance.BlackPawnTile;

        public override List<Vector2Int> GetMovements(Piece[,] piece)
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            if (Color == PieceColor.White)
            {
                movements.Add(new Vector2Int(0, 1));
                movements.Add(new Vector2Int(0, 2));
            }
            else
            {
                movements.Add(new Vector2Int(0, -1));
                movements.Add(new Vector2Int(0, -2));
            }
        
            return movements;
        }

        public Pawn(PieceColor color) : base(color) { }
    }
}