﻿#if NET40
namespace DotNetty.Buffers
{
    partial class ArrayPooledByteBuffer
    {
        public override bool HasMemoryAddress => false;

        public override ref byte GetPinnableMemoryAddress() => throw new System.NotSupportedException();
    }
}
#endif