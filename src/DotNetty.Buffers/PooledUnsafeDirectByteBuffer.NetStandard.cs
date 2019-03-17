﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if !NET40
namespace DotNetty.Buffers
{
    using System;
    using System.Buffers;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    unsafe partial class PooledUnsafeDirectByteBuffer
    {
        public override ReadOnlyMemory<byte> GetReadableMemory(int index, int count)
        {
            this.CheckIndex(index, count);
            index = this.Idx(index);
            return MemoryMarshal.CreateFromPinnedArray(this.Memory, index, count);
        }

        public override ReadOnlySpan<byte> GetReadableSpan(int index, int count)
        {
            this.CheckIndex(index, count);
            index = this.Idx(index);
            return new ReadOnlySpan<byte>(Unsafe.AsPointer(ref this.Memory[this.Offset]), count);
        }

        public override ReadOnlySequence<byte> GetSequence(int index, int count)
        {
            return ReadOnlyBufferSegment.Create(new[] { GetReadableMemory(index, count) });
        }

        public override Memory<byte> GetMemory(int index, int count)
        {
            this.CheckIndex(index, count);
            index = this.Idx(index);
            return MemoryMarshal.CreateFromPinnedArray(this.Memory, index, count);
        }

        public override Span<byte> GetSpan(int index, int count)
        {
            this.CheckIndex(index, count);
            index = this.Idx(index);
            return new Span<byte>(Unsafe.AsPointer(ref this.Memory[this.Offset]), count);
        }
    }
}
#endif