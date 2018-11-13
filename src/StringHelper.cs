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

namespace Touchjet.BinaryUtils
{
    /// <summary>
    /// String helper.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Convert a string containing 2-digit hexadecimal values into a byte array.
        /// </summary>
        /// <returns>The bytes.</returns>
        /// <param name="the_string">The string.</param>
        public static byte[] ToBytes(this string the_string)
        {
            if (the_string.Length < 2)
            {
                throw new ArgumentOutOfRangeException(the_string, "Input string is too short.");
            }
            if (the_string.Length == 2)
            {
                return new byte[1] { Convert.ToByte(the_string, 16) };
            }
            else
            {
                char separator = the_string[2];
                string[] pairs;

                if (((separator >= '0') && (separator <= '9')) || ((separator >= 'a') && (separator <= 'f')) || ((separator >= 'A') && (separator <= 'F')))
                {
                    pairs = Enumerable.Range(0, the_string.Length / 2).Select(i => the_string.Substring(i * 2, 2)).ToArray();
                }
                else
                {
                    pairs = the_string.Split(separator);
                }

                byte[] bytes = new byte[pairs.Length];
                for (int i = 0; i < pairs.Length; i++)
                    bytes[i] = Convert.ToByte(pairs[i], 16);
                return bytes;
            }
        }

        /// <summary>
        /// Convert a string containing 2-digit hexadecimal values into a byte array.
        /// </summary>
        /// <returns>The bytes.</returns>
        /// <param name="the_string">The string.</param>
        /// <param name="startIndex">Start Index.</param>
        /// <param name="length">Length.</param>
        public static byte[] ToBytes(this string the_string, int startIndex, int length)
        {
            var bytes = new byte[length];
            Array.Copy(the_string.ToBytes(), startIndex, bytes, 0, length);
            return bytes;
        }
    }
}
