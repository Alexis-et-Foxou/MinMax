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
            Debug.Log("position" + (Position.x + 1) + (Position.y +1));

            List<Vector2Int> movements = new List<Vector2Int>();
            int[] xDirections = { 1, 1, -1, -1 };
            int[] yDirections = { 1, -1, 1, -1 };
            
            for (int d = 0; d < 4; d++)
            {
                int dx = xDirections[d];
                int dy = yDirections[d];

                for (int i = 1; i < 8; i++)
                {
                    int newX = Position.x + (i * dx);
                    int newY = Position.y + (i * dy);
                    
                    if (newX < 0 || newX >= 8 || newY < 0 || newY >= 8) break;

                    Vector2Int movement = new Vector2Int(newX, newY);
                    Piece otherPiece = piece[movement.x, movement.y];
                    if (otherPiece != null && otherPiece.Color == Color) break;
                    movements.Add(movement);
                    if (otherPiece != null && otherPiece.Color != Color) break;
                }
            }
            return movements;
        }
    }
}