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
using System.Linq;
using System.Text;

namespace Touchjet.BinaryUtils
{
    public class ByteBuffer
    {
        readonly Endianness _endianness;

        public byte[] Value { get; }

        public int Position { get; private set; }

        public ByteBuffer(uint size, Endianness endianness)
        {
            Value = Enumerable.Repeat((byte)0, (int)size).ToArray();
            _endianness = endianness;
        }

        public void PutHex(string hexString)
        {
            Put(hexString.ToBytes());
        }

        public void PutASCII(string asciiString)
        {
            Put(Encoding.ASCII.GetBytes(asciiString));
        }

        public void Put(UInt16 value)
        {
            Put(value.ToBytes(_endianness));
        }

        public void Put(UInt32 value)
        {
            Put(value.ToBytes(_endianness));
        }

        public void Put(UInt64 value)
        {
            Put(value.ToBytes(_endianness));
        }

        public void Put(byte theByte)
        {
            if (Position >= Value.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            Value[Position] = theByte;
            Position++;
        }

        public void Put(byte[] bytes, int startIndex, int length)
        {
            if (Position + length >= Value.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            Buffer.BlockCopy(bytes, startIndex, Value, Position, length);
            Position += length;
        }

        public void Put(byte[] bytes)
        {
            Put(bytes, 0, bytes.Length);
        }
    }
}
