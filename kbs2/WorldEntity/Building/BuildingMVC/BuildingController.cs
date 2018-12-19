﻿using System.Collections.Generic;
using kbs2.Actions.ActionMVC;
using kbs2.Actions.Interfaces;
using kbs2.Desktop.GamePackage.EventArgs;
using kbs2.Faction.FactionMVC;
using kbs2.World;
using kbs2.World.Cell;
using kbs2.World.Structs;
using kbs2.WorldEntity.Interfaces;

namespace kbs2.WorldEntity.Building.BuildingMVC
{
    public class BuildingController : IStructure, IHasGameActions
    {
        private readonly List<IGameAction> actions = new List<IGameAction>();

        public BuildingController(IStructureDef def)
        {
            Def = def;
        }

        public BuildingModel Model { get; } = new BuildingModel();
        public BuildingView View { get; set; }

        public FloatCoords FloatCoords => (FloatCoords) Model.TopLeft;

        public List<IGameAction> GameActions => actions;
        public List<WorldCellModel> OccupiedCells => Model.LocationCells;

        public Coords StartCoords
        {
            get => Model.TopLeft;
            set => Model.TopLeft = value;
        }

        public IStructureDef Def { get; }

        public Faction_Controller Faction { get; set; }

        public void Update(object sender, OnTickEventArgs eventArgs)
        {
        }
    }
}