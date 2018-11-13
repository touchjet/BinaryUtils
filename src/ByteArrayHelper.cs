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
    /// <summary>
    /// Byte array helper.
    /// </summary>
    public static class ByteArrayHelper
    {
        /// <summary>
        /// Return a string that represents the byte array as a series of hexadecimal values separated by a separator character.
        /// </summary>
        /// <returns>The hex.</returns>
        /// <param name="the_bytes">The bytes.</param>
        /// <param name="separator">Separator.</param>
        public static string ToHex(this byte[] the_bytes, string separator="")
        {
            return BitConverter.ToString(the_bytes, 0).Replace("-", separator);
        }

        /// <summary>
        /// Return a string that represents the byte array as a series of hexadecimal values separated by a separator character.
        /// </summary>
        /// <returns>The hex.</returns>
        /// <param name="the_bytes">The bytes.</param>
        /// <param name="startIndex">Start Index.</param>
        /// <param name="length">Length.</param>
        /// <param name="separator">Separator.</param>
        public static string ToHex(this byte[] the_bytes, int startIndex, int length, string separator = "")
        {
            return BitConverter.ToString(the_bytes, startIndex,length).Replace("-", separator);
        }

    }
}
