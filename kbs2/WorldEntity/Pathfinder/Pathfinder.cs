﻿using System;
using System.Collections.Generic;
using kbs2.Desktop.World.World;
using kbs2.Unit.Model;
using kbs2.World;
using kbs2.World.Cell;
using kbs2.World.Structs;


public struct CellWeight
{
    public double DistanceToTarget;
    public double DistanceToUnit;
    public double Weight => DistanceToTarget + DistanceToUnit;
}

public struct WeightDictionarys
{
    public WeightDictionarys(bool shit)// bool does nothing but is required
    {
        CellsWithWeight = new Dictionary<Coords, CellWeight>();
        BorderCellsWithWeight = new Dictionary<Coords, CellWeight>();
        ObstacleList = new List<Coords>();
    }

    public Dictionary<Coords, CellWeight> CellsWithWeight;
    public Dictionary<Coords, CellWeight> BorderCellsWithWeight;
    public List<Coords> ObstacleList;
}

public class Pathfinder
{
    
    WorldModel worldModel;
    public int Limit { get; set; }

    static Func<double, double, double> pythagoras = (x, y) => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    static Func<double, double, double> getDistance = (x, y) => x > y ? x - y : y - x;
    Func<Coords, Coords, double> getDistance2d = (a, b) => pythagoras(getDistance(a.x, b.x), getDistance(a.y, b.y));


    public Pathfinder(WorldModel worldModel,int limit)
	{
        this.worldModel = worldModel;
        Limit = limit;
	}

    public List<Coords> FindPath(FloatCoords TargetCoords, Unit_Model unit)
    {
        WeightDictionarys weightDictionarys = new WeightDictionarys(true);

        //TODO add unit cell that contains unit to CellsWithWeight
        Coords targetIntCoords;
        targetIntCoords.x = (int)TargetCoords.x;
        targetIntCoords.y = (int)TargetCoords.y;

        for (int i = 0; i<Limit*2*Limit*2*2;i++)
        {

            double lowestWeight = double.MaxValue;
            Coords lowestCoords = new Coords();
            bool isset = false;
            foreach (KeyValuePair<Coords, CellWeight> entry in weightDictionarys.BorderCellsWithWeight)
            {
                if (entry.Value.Weight < lowestWeight)
                {
                    lowestWeight = entry.Value.Weight;
                    lowestCoords = entry.Key;
                    isset = true;
                }
            }

            if (isset)
            {
                CalculateWeight(lowestCoords, targetIntCoords, unit, weightDictionarys);
                weightDictionarys.BorderCellsWithWeight.Remove(lowestCoords);
            }
            else
            {
                // TODO no path found
            }

            if (weightDictionarys.CellsWithWeight.ContainsKey(targetIntCoords))
            {
                // path found
                break;
            }
        }

        return null;
    }

    private void CalculateWeight(Coords currentCell, Coords TargetCoords, Unit_Model unit, WeightDictionarys weightDictionarys)
    {
        Coords[] loop = new Coords[4];
        loop[0] = new Coords { x = 1, y = 0 };
        loop[1] = new Coords { x = -1, y = 0 };
        loop[2] = new Coords { x = 0, y = 1 };
        loop[3] = new Coords { x = 0, y = -1 };




        for (int i = 0; i<4; i++)
        {

            Coords coords = currentCell + loop[i];

            if (!weightDictionarys.CellsWithWeight.ContainsKey(coords)||!weightDictionarys.ObstacleList.Contains(coords))
            {
                Coords chunkCoords;
                chunkCoords.x = coords.x / worldModel.ChunkSize;
                chunkCoords.y = coords.y / worldModel.ChunkSize;
                    
                int coordsInChunkx = coords.x % worldModel.ChunkSize;
                int coordsInChunky = coords.y % worldModel.ChunkSize;

                WorldCellModel cell;
                cell = worldModel.ChunkGrid[chunkCoords].worldChunkModel.grid[coordsInChunkx, coordsInChunky];

                if (!CellIsObstacle(cell, unit))
                {
                    CellWeight cellWeight;

                        
                    cellWeight.DistanceToTarget = getDistance2d(coords, TargetCoords)*10;

                    cellWeight.DistanceToUnit = weightDictionarys.CellsWithWeight[currentCell].DistanceToUnit + 10;
                    
                    if(cellWeight.DistanceToTarget<Limit || cellWeight.DistanceToUnit < Limit)
                    {
                        weightDictionarys.BorderCellsWithWeight.Add(coords, cellWeight);
                        weightDictionarys.CellsWithWeight.Add(coords, cellWeight);
                    }
                }
                else
                {
                    weightDictionarys.ObstacleList.Add(coords);
                }
            }
        }
    }

    private bool CellIsObstacle(WorldCellModel Cell, Unit_Model unit)
    {
        bool r = true;
        if (unit.UnwalkableTerrain.Contains(Cell.terrain))
        {
            r = false;
        }
        // todo check buildings

        return r;
    }

    private List<FloatCoords> MinimizeWaypoints(List<Coords> RouteCells)
    {
        return null;
    }

    // Checks if 
    private bool CheckDiagonalsBlocked(Coords one, Coords two, WeightDictionarys stuf)
    {
        //checks if coord are not next to each other
        if (one.x == two.x || one.y == two.y)
        {
            return false;
        }

        Coords three;
        three.x = one.x;
        three.y = two.y;

        Coords four;
        four.x = two.x;
        four.y = one.y;

        //Checks if both coords are blocked by an obstacle
        if(stuf.ObstacleList.Contains(three) && stuf.ObstacleList.Contains(four))
        {
            return false;
        }

        return true;
    }
}
