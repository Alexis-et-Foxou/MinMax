using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace Pieces
{
    public class Rook : Piece
    {
        public override Tile Tile => 
            Color == PieceColor.White ? GameManager.Instance.WhiteRookTile : GameManager.Instance.BlackRookTile;
        public Rook(PieceColor color) : base(color) { }
        
        public override List<Vector2Int> GetMovements()
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(0, i));
            }
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(0, -i));
            }
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(i, 0));
            }
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(-i, 0));
            }
        
            return movements;
        }
    }
}