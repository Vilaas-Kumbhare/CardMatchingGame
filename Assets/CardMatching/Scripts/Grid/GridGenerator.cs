using System.Collections.Generic;
using CardMatching.Scripts.Cards;
using UnityEngine;

namespace CardMatching.Scripts.Grid
{
    public class GridGenerator: IGridGenerator
    {
        private List<Card> _cards;
        private int _rows;
        private int _columns;
        private float _spacing;

        public GridGenerator(List<Card> cards, int rows = 4, int columns = 4, float spacing = 2.0f)
        {
            _cards = cards;
            _rows = rows;
            _columns = columns;
            _spacing = spacing;
        }
        
        public void GenerateGrid(Transform parent = null)
        {
            if (_cards == null || _cards.Count == 0)
            {
                Debug.LogWarning("No cards available to populate the grid.");
                return;
            }

            int cardIndex = 0;

            // Calculate grid dimensions
            float gridWidth = (_columns - 1) * _spacing;
            float gridHeight = (_rows - 1) * _spacing;

            // Calculate starting offset to center the grid
            Vector3 startOffset = new Vector3(-gridWidth / 2, -gridHeight / 2, 0);

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    if (cardIndex >= _cards.Count)
                    {
                        Debug.LogWarning("Not enough cards to populate the grid.");
                        return;
                    }

                    // Calculate the position of each card
                    Vector3 position = new Vector3(column * _spacing, row * _spacing, 0) + startOffset;

                    // Set the position
                    _cards[cardIndex].transform.position = position;

                    // Set parent if provided
                    if (parent != null)
                    {
                        _cards[cardIndex].transform.SetParent(parent, worldPositionStays: false);
                    }

                    cardIndex++;
                }
            }
        }
    }
}
