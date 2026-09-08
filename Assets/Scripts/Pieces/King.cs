using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace Pieces
{
    public class King : Piece
    {
        public override Tile Tile => Color == PieceColor.White ? 
            GameManager.Instance.WhiteKingTile : GameManager.Instance.BlackKingTile;
        
        public King(PieceColor color) : base(color) { }
        
        public override List<Vector2Int> GetMovements()
        {
            List<Vector2Int> movements = new List<Vector2Int>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // On ignore la cellule cible
                    if (i == 0 && j == 0) continue;
                    
                    movements.Add(new Vector2Int(i, j));
                }
            }
            return movements;
        }
    }
}