using System;
using kbs2.World.Cell;

namespace kbs2.World.Chunk
{
    public static class WorldChunkFactory
    {
        public static WorldChunkController ChunkOfTerrainType(Coords chunkCoords, TerrainType terrainType)
        {
            Func<int, int, int> rowIndex = (d2Index, rowSize) => d2Index % rowSize;
            Func<int, int, int> colIndex = (d2Index, rowSize) => (int) Math.Floor((double) (d2Index / rowSize));

            WorldChunkController controller = new WorldChunkController(chunkCoords);

            //int xIndex = 0, yIndex = 0; 
            foreach (WorldCellModel worldCellModel in controller.worldChunkModel.grid)
            {
                worldCellModel.BaseTerrain = worldCellModel.Terrain = terrainType;
            }

            return controller;
        }
    }
}