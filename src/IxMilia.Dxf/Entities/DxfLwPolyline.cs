﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Linq;

namespace IxMilia.Dxf.Entities
{
    public partial class DxfLwPolyline
    {
        internal override DxfEntity PopulateFromBuffer(DxfCodePairBufferReader buffer)
        {
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                if (pair.Code == 0)
                {
                    break;
                }

                while (this.TrySetExtensionData(pair, buffer))
                {
                    pair = buffer.Peek();
                }

                switch (pair.Code)
                {
                    // vertex-specific pairs
                    case 10:
                        // start a new vertex
                        Vertices.Add(new DxfLwPolylineVertex());
                        Vertices.Last().X = pair.DoubleValue;
                        break;
                    case 20:
                        Vertices.Last().Y = pair.DoubleValue;
                        break;
                    case 40:
                        Vertices.Last().StartingWidth = pair.DoubleValue;
                        break;
                    case 41:
                        Vertices.Last().EndingWidth = pair.DoubleValue;
                        break;
                    case 42:
                        Vertices.Last().Bulge = pair.DoubleValue;
                        break;
                    case 91:
                        Vertices.Last().Identifier = pair.IntegerValue;
                        break;
                    // all other pairs
                    case 39:
                        Thickness = pair.DoubleValue;
                        break;
                    case 43:
                        ConstantWidth = pair.DoubleValue;
                        break;
                    case 70:
                        Flags = pair.ShortValue;
                        break;
                    case 210:
                        ExtrusionDirection.X = pair.DoubleValue;
                        break;
                    case 220:
                        ExtrusionDirection.Y = pair.DoubleValue;
                        break;
                    case 230:
                        ExtrusionDirection.Z = pair.DoubleValue;
                        break;
                    default:
                        if (!base.TrySetPair(pair))
                        {
                            ExcessCodePairs.Add(pair);
                        }
                        break;
                }

                buffer.Advance();
            }

            return PostParse();
        }
    }
}
