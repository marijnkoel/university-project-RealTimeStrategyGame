﻿using System;
using System.Collections.Generic;
using kbs2.World;
using kbs2.World.Enums;
using kbs2.World.Structs;
using kbs2.World.World;
using kbs2.WorldEntity.Location;
using kbs2.WorldEntity.Pathfinder;

namespace PathfindingConsoleApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            WorldController world = WorldFactory.GetNewWorld();

            Random random = new Random();
            Coords coords = new Coords();
            coords.x = 0;
            coords.y = 0;


            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    if (x == 9 && y == 9)
                    {
                        continue;
                    }

                    if (random.Next(3) == 0)
                    {
                        world.WorldModel.ChunkGrid[coords].WorldChunkModel.grid[x, y].worldCellModel.Terrain =
                            TerrainType.Water;
                    }
                }
            }

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    FloatCoords currentCoords = new FloatCoords();
                    currentCoords.x = x;
                    currentCoords.y = y;
                    if (world.WorldModel.ChunkGrid[coords].WorldChunkModel.grid[x, y].worldCellModel.Terrain ==
                        TerrainType.Water)
                    {
                        Console.Write("W ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();


            Pathfinder pathfinder = new Pathfinder(world, 150);


            LocationModel locationModel = new LocationModel(0, 0);
            locationModel.UnwalkableTerrain = new List<TerrainType>();
            locationModel.UnwalkableTerrain.Add(TerrainType.Water);
            locationModel.FloatCoords.x = 0;
            locationModel.FloatCoords.y = 0;

            FloatCoords floatCoords = new FloatCoords();
            floatCoords.x = 9;
            floatCoords.y = 9;

            List<FloatCoords> waypoints = pathfinder.FindPath(floatCoords, locationModel);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    FloatCoords currentCoords = new FloatCoords();
                    currentCoords.x = x;
                    currentCoords.y = y;
                    if (waypoints.Contains(currentCoords))
                    {
                        Console.Write(waypoints.IndexOf(currentCoords) + " ");
                    }
                    else
                    {
                        if (world.WorldModel.ChunkGrid[coords].WorldChunkModel.grid[x, y].worldCellModel.Terrain ==
                            TerrainType.Water)
                        {
                            Console.Write("W ");
                        }
                        else
                        {
                            Console.Write("* ");
                        }
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            waypoints = pathfinder.FindPath2(floatCoords, locationModel);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    FloatCoords currentCoords = new FloatCoords();
                    currentCoords.x = x;
                    currentCoords.y = y;
                    if (waypoints.Contains(currentCoords))
                    {
                        Console.Write(waypoints.IndexOf(currentCoords) + " ");
                    }
                    else
                    {
                        if (world.WorldModel.ChunkGrid[coords].WorldChunkModel.grid[x, y].worldCellModel.Terrain ==
                            TerrainType.Water)
                        {
                            Console.Write("W ");
                        }
                        else
                        {
                            Console.Write("* ");
                        }
                    }
                }

                Console.WriteLine();
            }

            Console.Read();
        }
    }
}