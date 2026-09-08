using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

namespace Pieces
{
    public abstract class Piece
    {
        public PieceColor Color;
        public abstract Tile Tile { get; }

        protected Piece(PieceColor color)
        {
            this.Color = color;
        }

        public abstract List<Vector2Int> GetMovements();
    }
}