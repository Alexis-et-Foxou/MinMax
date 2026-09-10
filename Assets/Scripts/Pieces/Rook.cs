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
        
        public override List<Vector2Int> GetMovements(Piece[,] piece)
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            for (int i = Position.x +1; i < 8; i++)
            {
                Vector2Int movement = new Vector2Int(i, Position.y);
                Piece otherPiece = piece[movement.x, movement.y];
                if (otherPiece != null && otherPiece.Color == Color) break;
                movements.Add(movement);
                if (otherPiece != null && otherPiece.Color != Color) break;
            }
            
            for (int i = Position.x -1; i >= 0; i--)
            {
                movements.Add(new Vector2Int(i, Position.y));
            }
            
            for (int i = Position.x +1; i < 8; i++)
            {
                movements.Add(new Vector2Int(Position.x, i));
            }
            
            for (int i = Position.x -1; i >= 0; i--)
            {
                movements.Add(new Vector2Int(Position.x, i));
            }
        
            return movements;
        }
    }
}