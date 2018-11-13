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
using System.Collections.Generic;
using System.IO;

namespace Touchjet.BinaryUtils
{
    public static class ArraySegmentExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySegment{T}"/> structure that delimits the specified
        /// range of the elements in the specified array.
        /// </summary>
        public static ArraySegment<T> Segment<T>(this T[] array, int offset, int count)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            return new ArraySegment<T>(array, offset, count);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySegment{T}"/> structure that delimits the specified
        /// number of the elements in the specified array starting from offset 0.
        /// </summary>
        public static ArraySegment<T> Segment<T>(this T[] array, int count)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            return new ArraySegment<T>(array, 0, count);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySegment{T}"/> structure that delimits all the elements
        /// in the specified array.
        /// </summary>
        public static ArraySegment<T> Segment<T>(this T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            return new ArraySegment<T>(array);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySegment{T}"/> structure that delimits the specified
        /// range of the elements in the specified segment.
        /// </summary>
        public static ArraySegment<T> Segment<T>(this ArraySegment<T> segment, int offset, int count)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            ThrowIfNegative(offset, nameof(offset));
            ThrowIfNegative(count, nameof(count));

            if (offset + count > segment.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                    $"The offset ({offset}) and count ({count}) must define a new segment that is inside the input segment (With count {segment.Count})");
            }

            return new ArraySegment<T>(segment.Array, segment.Offset + offset, count);
        }

        static void ThrowIfNegative(int value, string name)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(name, "Offset can't be negative");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySegment{T}"/> structure that delimits all elements
        /// after and including the specified one.
        /// </summary>
        public static ArraySegment<T> Segment<T>(this ArraySegment<T> segment, int offset)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            ThrowIfNegative(offset, nameof(offset));

            if (offset > segment.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(offset),
                    $"The offset ({offset}) must be inferior or equal to the count of the input segment ({segment.Count})");
            }

            return new ArraySegment<T>(segment.Array, segment.Offset + offset, segment.Count - offset);
        }

        /// <summary>
        /// Wrap the segment in a <see cref="Stream"/> instance.
        /// </summary>
        public static Stream AsStream(this ArraySegment<byte> segment)
        {
            return new MemoryStream(segment.Array, segment.Offset, segment.Count);
        }

        public static T[] ToNewArray<T>(this ArraySegment<T> segment)
        {
            var result = new T[segment.Count];
            Array.Copy(segment.Array, segment.Offset, result, 0, segment.Count);
            return result;
        }

        /// <summary>
        /// Wrap the segment in a <see cref="IEnumerable{T}"/> instance.
        /// </summary>
        public static IEnumerable<T> AsEnumerable<T>(this ArraySegment<T> segment)
        {
            for (int i = 0; i < segment.Count; i++)
            {
                var index = i + segment.Offset;
                yield return segment.Array[index];
            }
        }

        public static bool ContentEquals<T>(this ArraySegment<T> @this, ArraySegment<T> other,
            IEqualityComparer<T> comparer = null)
        {
            if (@this.Count != other.Count)
            {
                return false;
            }

            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            for (int i = 0; i < @this.Count; i++)
            {
                var thisValue = @this.Array[@this.Offset + i];
                var otherValue = other.Array[other.Offset + i];

                if (!comparer.Equals(thisValue, otherValue))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ToHex(this ArraySegment<byte> segment)
        {
            return segment.Array.ToHex();
        }

        public static string ToHex(this ArraySegment<byte> segment, int startIndex, int length, string separator = "")
        {
            return segment.Array.ToHex(startIndex,length,separator);
        }
    }
}
