using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace Pieces
{
    public class Queen : Piece
    {
        public override Tile Tile => 
            Color == PieceColor.White ? GameManager.Instance.WhiteQueenTile : GameManager.Instance.BlackQueenTile;
        public Queen(PieceColor color) : base(color) { }
        
        public override List<Vector2Int> GetMovements()
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            for (int i = 1; i < 7; i++)
            {
                movements.Add(new Vector2Int(0, i));
            }
            for (int i = 1; i < 7 ; i++)
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