// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfUnderlay class
    /// </summary>
    public partial class DxfUnderlay : DxfEntity, IDxfItemInternal
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Underlay; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2007; } }

        IEnumerable<DxfPointer> IDxfItemInternal.GetPointers()
        {
            yield return ObjectPointer;
        }

        IEnumerable<IDxfItemInternal> IDxfItemInternal.GetChildItems()
        {
            return ((IDxfItemInternal)this).GetPointers().Select(p => (IDxfItemInternal)p.Item);
        }

        internal DxfPointer ObjectPointer { get; } = new DxfPointer();
        public IDxfItem Object { get { return ObjectPointer.Item as IDxfItem; } set { ObjectPointer.Item = value; } }
        public DxfPoint InsertionPoint { get; set; }
        public double XScale { get; set; }
        public double YScale { get; set; }
        public double ZScale { get; set; }
        public double RotationAngle { get; set; }
        public DxfVector Normal { get; set; }
        public int Flags { get; set; }
        public short Contrast { get; set; }
        public short Fade { get; set; }
        private IList<double> _pointX { get; set; }
        private IList<double> _pointY { get; set; }

        // Flags flags

        public bool IsClippingOn
        {
            get { return DxfHelpers.GetFlag(Flags, 1); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 1);
                Flags = flags;
            }
        }

        public bool IsUnderlayOn
        {
            get { return DxfHelpers.GetFlag(Flags, 2); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 2);
                Flags = flags;
            }
        }

        public bool IsMonochrome
        {
            get { return DxfHelpers.GetFlag(Flags, 4); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 4);
                Flags = flags;
            }
        }

        public bool AdjustForBackground
        {
            get { return DxfHelpers.GetFlag(Flags, 8); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 8);
                Flags = flags;
            }
        }

        public bool IsClipInsideMode
        {
            get { return DxfHelpers.GetFlag(Flags, 16); }
            set
            {
                var flags = Flags;
                DxfHelpers.SetFlag(value, ref flags, 16);
                Flags = flags;
            }
        }

        internal DxfUnderlay()
            : base()
        {
        }

        protected DxfUnderlay(DxfUnderlay other)
            : base(other)
        {
            this.ObjectPointer.Handle = other.ObjectPointer.Handle;
            this.ObjectPointer.Item = other.ObjectPointer.Item;
            this.InsertionPoint = other.InsertionPoint;
            this.XScale = other.XScale;
            this.YScale = other.YScale;
            this.ZScale = other.ZScale;
            this.RotationAngle = other.RotationAngle;
            this.Normal = other.Normal;
            this.Flags = other.Flags;
            this.Contrast = other.Contrast;
            this.Fade = other.Fade;
            this._pointX = other._pointX;
            this._pointY = other._pointY;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.InsertionPoint = DxfPoint.Origin;
            this.XScale = 1.0;
            this.YScale = 1.0;
            this.ZScale = 1.0;
            this.RotationAngle = 0.0;
            this.Normal = DxfVector.ZAxis;
            this.Flags = 0;
            this.Contrast = 100;
            this.Fade = 0;
            this._pointX = new ListNonNull<double>();
            this._pointY = new ListNonNull<double>();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
            base.AddValuePairs(pairs, version, outputHandles);
            pairs.Add(new DxfCodePair(100, "AcDbUnderlayReference"));
            if (this.ObjectPointer.Handle != 0u)
            {
                pairs.Add(new DxfCodePair(340, DxfCommonConverters.UIntHandle(this.ObjectPointer.Handle)));
            }

            pairs.Add(new DxfCodePair(10, InsertionPoint?.X ?? default(double)));
            pairs.Add(new DxfCodePair(20, InsertionPoint?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(30, InsertionPoint?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(41, (this.XScale)));
            pairs.Add(new DxfCodePair(42, (this.YScale)));
            pairs.Add(new DxfCodePair(43, (this.ZScale)));
            pairs.Add(new DxfCodePair(50, (this.RotationAngle)));
            pairs.Add(new DxfCodePair(210, Normal?.X ?? default(double)));
            pairs.Add(new DxfCodePair(220, Normal?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(230, Normal?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(280, (short)(this.Flags)));
            pairs.Add(new DxfCodePair(281, (this.Contrast)));
            pairs.Add(new DxfCodePair(282, (this.Fade)));
            foreach (var item in BoundaryPoints)
            {
                pairs.Add(new DxfCodePair(11, item.X));
                pairs.Add(new DxfCodePair(12, item.Y));
            }

        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 10:
                    this.InsertionPoint.X = pair.DoubleValue;
                    break;
                case 20:
                    this.InsertionPoint.Y = pair.DoubleValue;
                    break;
                case 30:
                    this.InsertionPoint.Z = pair.DoubleValue;
                    break;
                case 11:
                    this._pointX.Add((pair.DoubleValue));
                    break;
                case 21:
                    this._pointY.Add((pair.DoubleValue));
                    break;
                case 41:
                    this.XScale = (pair.DoubleValue);
                    break;
                case 42:
                    this.YScale = (pair.DoubleValue);
                    break;
                case 43:
                    this.ZScale = (pair.DoubleValue);
                    break;
                case 50:
                    this.RotationAngle = (pair.DoubleValue);
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
                case 280:
                    this.Flags = (int)(pair.ShortValue);
                    break;
                case 281:
                    this.Contrast = (pair.ShortValue);
                    break;
                case 282:
                    this.Fade = (pair.ShortValue);
                    break;
                case 340:
                    this.ObjectPointer.Handle = DxfCommonConverters.UIntHandle(pair.StringValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}
