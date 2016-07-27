// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfSpline class
    /// </summary>
    public partial class DxfSpline : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Spline; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R13; } }
        public DxfVector Normal { get; set; }
        public int Flags { get; set; }
        public int DegreeOfCurve { get; set; }
        private int _numberOfKnotsIgnored { get; set; }
        private int _numberOfControlPointsIgnored { get; set; }
        private int _numberOfFitPointsIgnored { get; set; }
        public double KnotTolerance { get; set; }
        public double ControlPointTolerance { get; set; }
        public double FitTolerance { get; set; }
        public DxfPoint StartTangent { get; set; }
        public DxfPoint EndTangent { get; set; }
        public IList<double> KnotValues { get; private set; }
        public double Weight { get; set; }
        private IList<double> _controlPointX { get; set; }
        private IList<double> _controlPointY { get; set; }
        private IList<double> _controlPointZ { get; set; }
        private IList<double> _fitPointX { get; set; }
        private IList<double> _fitPointY { get; set; }
        private IList<double> _fitPointZ { get; set; }

        // Flags flags

        public bool IsClosed
        {
            get { return DxfHelpers.GetFlag(Flags, 1); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 1);
                Flags = flags;
            }
        }

        public bool IsPeriodic
        {
            get { return DxfHelpers.GetFlag(Flags, 2); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 2);
                Flags = flags;
            }
        }

        public bool IsRational
        {
            get { return DxfHelpers.GetFlag(Flags, 4); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 4);
                Flags = flags;
            }
        }

        public bool IsPlanar
        {
            get { return DxfHelpers.GetFlag(Flags, 8); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 8);
                Flags = flags;
            }
        }

        public bool IsLinear
        {
            get { return DxfHelpers.GetFlag(Flags, 16); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 16);
                Flags = flags;
            }
        }

        public DxfSpline()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Normal = DxfVector.ZAxis;
            this.Flags = 0;
            this.DegreeOfCurve = 1;
            this._numberOfKnotsIgnored = 0;
            this._numberOfControlPointsIgnored = 0;
            this._numberOfFitPointsIgnored = 0;
            this.KnotTolerance = 0.0000001;
            this.ControlPointTolerance = 0.0000001;
            this.FitTolerance = 0.0000000001;
            this.StartTangent = DxfPoint.Origin;
            this.EndTangent = DxfPoint.Origin;
            this.KnotValues = new List<double>();
            this.Weight = 1.0;
            this._controlPointX = new List<double>();
            this._controlPointY = new List<double>();
            this._controlPointZ = new List<double>();
            this._fitPointX = new List<double>();
            this._fitPointY = new List<double>();
            this._fitPointZ = new List<double>();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
            base.AddValuePairs(pairs, version, outputHandles);
            pairs.Add(new DxfCodePair(100, "AcDbSpline"));
            pairs.Add(new DxfCodePair(210, Normal?.X ?? default(double)));
            pairs.Add(new DxfCodePair(220, Normal?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(230, Normal?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(70, (short)(this.Flags)));
            pairs.Add(new DxfCodePair(71, (short)(this.DegreeOfCurve)));
            pairs.Add(new DxfCodePair(72, (short?)KnotValues?.Count ?? default(short)));
            pairs.Add(new DxfCodePair(73, (short?)ControlPoints?.Count ?? default(short)));
            pairs.Add(new DxfCodePair(74, (short?)FitPoints?.Count ?? default(short)));
            if (this.KnotTolerance != 0.0000001)
            {
                pairs.Add(new DxfCodePair(42, (this.KnotTolerance)));
            }

            if (this.ControlPointTolerance != 0.0000001)
            {
                pairs.Add(new DxfCodePair(43, (this.ControlPointTolerance)));
            }

            if (this.FitTolerance != 0.0000000001)
            {
                pairs.Add(new DxfCodePair(44, (this.FitTolerance)));
            }

            pairs.Add(new DxfCodePair(12, StartTangent?.X ?? default(double)));
            pairs.Add(new DxfCodePair(22, StartTangent?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(32, StartTangent?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(13, EndTangent?.X ?? default(double)));
            pairs.Add(new DxfCodePair(23, EndTangent?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(33, EndTangent?.Z ?? default(double)));
            pairs.AddRange(this.KnotValues.Select(p => new DxfCodePair(40, p)));
            if (this.Weight != 1.0)
            {
                pairs.Add(new DxfCodePair(41, (this.Weight)));
            }

            foreach (var item in ControlPoints)
            {
                pairs.Add(new DxfCodePair(10, item.X));
                pairs.Add(new DxfCodePair(20, item.Y));
                pairs.Add(new DxfCodePair(30, item.Z));
            }

            foreach (var item in FitPoints)
            {
                pairs.Add(new DxfCodePair(11, item.X));
                pairs.Add(new DxfCodePair(21, item.Y));
                pairs.Add(new DxfCodePair(31, item.Z));
            }

        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 10:
                    this._controlPointX.Add((pair.DoubleValue));
                    break;
                case 11:
                    this._fitPointX.Add((pair.DoubleValue));
                    break;
                case 12:
                    this.StartTangent.X = pair.DoubleValue;
                    break;
                case 22:
                    this.StartTangent.Y = pair.DoubleValue;
                    break;
                case 32:
                    this.StartTangent.Z = pair.DoubleValue;
                    break;
                case 13:
                    this.EndTangent.X = pair.DoubleValue;
                    break;
                case 23:
                    this.EndTangent.Y = pair.DoubleValue;
                    break;
                case 33:
                    this.EndTangent.Z = pair.DoubleValue;
                    break;
                case 20:
                    this._controlPointY.Add((pair.DoubleValue));
                    break;
                case 21:
                    this._fitPointY.Add((pair.DoubleValue));
                    break;
                case 30:
                    this._controlPointZ.Add((pair.DoubleValue));
                    break;
                case 31:
                    this._fitPointZ.Add((pair.DoubleValue));
                    break;
                case 40:
                    this.KnotValues.Add((pair.DoubleValue));
                    break;
                case 41:
                    this.Weight = (pair.DoubleValue);
                    break;
                case 42:
                    this.KnotTolerance = (pair.DoubleValue);
                    break;
                case 43:
                    this.ControlPointTolerance = (pair.DoubleValue);
                    break;
                case 44:
                    this.FitTolerance = (pair.DoubleValue);
                    break;
                case 70:
                    this.Flags = (int)(pair.ShortValue);
                    break;
                case 71:
                    this.DegreeOfCurve = (int)(pair.ShortValue);
                    break;
                case 72:
                    this._numberOfKnotsIgnored = (int)(pair.ShortValue);
                    break;
                case 73:
                    this._numberOfControlPointsIgnored = (int)(pair.ShortValue);
                    break;
                case 74:
                    this._numberOfFitPointsIgnored = (int)(pair.ShortValue);
                    break;
                case 210:
                    this.Normal.X = pair.DoubleValue;
                    break;
                case 220:
                    this.Normal.Y = pair.DoubleValue;
                    break;
                case 230:
                    this.Normal.Z = pair.DoubleValue;
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}