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
            // Get the separator character.
            char separator = the_string[2];

            // Split at the separators.
            string[] pairs = the_string.Split(separator);
            byte[] bytes = new byte[pairs.Length];
            for (int i = 0; i < pairs.Length; i++)
                bytes[i] = Convert.ToByte(pairs[i], 16);
            return bytes;
        }
    }
}
