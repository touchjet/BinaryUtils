/*
 * Copyright (C) 2018 Touchjet Limited.
 * 
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
using System;

namespace Touchjet.BinaryUtils
{
    public static class UIntHelper
    {
        public static byte[] ToBytes(this UInt16 value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.LittleEndian:
                    return new byte[]
                    {
                (byte)value,
                (byte)(value >> 8),
                    };
                case Endianness.BigEndian:
                    return new byte[]
                    {
                (byte)(value >> 8),
                (byte)value,
                    };
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported Endianness {endianness}");
            }
        }

        public static byte[] ToBytes(this UInt32 value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.LittleEndian:
                    return new byte[]
                    {
                (byte)value,
                (byte)(value >> 8),
                (byte)(value >> 16),
                (byte)(value >> 24),
                    };
                case Endianness.BigEndian:
                    return new byte[]
                    {
                (byte)(value >> 24),
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value,
                    };
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported Endianness {endianness}");
            }
        }

        public static byte[] ToBytes(this UInt64 value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.LittleEndian:
                    return new byte[]
                    {
                (byte)value,
                (byte)(value >> 8),
                (byte)(value >> 16),
                (byte)(value >> 24),
                (byte)(value >> 32),
                (byte)(value >> 40),
                (byte)(value >> 48),
                (byte)(value >> 56),
                    };
                case Endianness.BigEndian:
                    return new byte[]
                    {
                (byte)(value >> 56),
                (byte)(value >> 48),
                (byte)(value >> 40),
                (byte)(value >> 32),
                (byte)(value >> 24),
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value,
                    };
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported Endianness {endianness}");
            }
        }
    }
}
