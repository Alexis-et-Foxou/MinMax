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
        
        public override List<Vector2Int> GetMovements()
        {
            List<Vector2Int> movements = new List<Vector2Int>();
        
            return movements;
        }
        
        // Il est tard, j'ai pas trouvé de solution viable
    }
}