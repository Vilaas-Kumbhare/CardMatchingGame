using UnityEngine;

namespace CardMatching.Scripts.Grid
{
    public interface IGridGenerator
    {
        public void GenerateGrid(Transform parent);
    }
}
