using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

namespace Pieces
{
    public abstract class Piece 
    {
        public PieceColor Color;
        public Vector2Int Position;
        public abstract Tile Tile { get; }

        protected Piece(PieceColor color)
        {
            this.Color = color;
        }

        public abstract List<Vector2Int> GetMovements(Piece[,] piece);
    }
}