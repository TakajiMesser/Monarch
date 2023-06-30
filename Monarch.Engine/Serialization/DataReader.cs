using Monarch.Engine.Maths;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace SpiceEngine.Core.Serialization
{
    public class DataReader : IDataReader, IDisposable
    {
        private readonly BinaryReader _reader;
        private bool _disposedValue;

        public DataReader(BinaryReader reader) => _reader = reader;

        public short ReadShort() => _reader.ReadInt16();
        public int ReadInt() => _reader.ReadInt32();
        public long ReadLong() => _reader.ReadInt64();

        public ushort ReadUShort() => _reader.ReadUInt16();
        public uint ReadUInt() => _reader.ReadUInt32();
        public ulong ReadULong() => _reader.ReadUInt64();

        public float ReadSingle() => _reader.ReadSingle();
        public double ReadDouble() => _reader.ReadDouble();

        public char ReadChar() => _reader.ReadChar();
        public string ReadString() => _reader.ReadString();

        public bool ReadBoolean() => _reader.ReadBoolean();
        public byte ReadByte() => _reader.ReadByte();
        public T ReadEnum<T>() where T : Enum
        {
            var value = _reader.ReadInt32();
            return Unsafe.As<int, T>(ref value);
        }

        public Type ReadType()
        {
            var typeName = _reader.ReadString();
            return Type.GetType(typeName)!;
        }

        public Vector2f ReadVector2() => new()
        {
            X = _reader.ReadSingle(),
            Y = _reader.ReadSingle()
        };

        public Vector3f ReadVector3() => new()
        {
            X = _reader.ReadSingle(),
            Y = _reader.ReadSingle(),
            Z = _reader.ReadSingle()
        };

        public Vector4f ReadVector4() => new()
        {
            X = _reader.ReadSingle(),
            Y = _reader.ReadSingle(),
            Z = _reader.ReadSingle(),
            W = _reader.ReadSingle()
        };

        public Quaternion ReadQuaternion() => new()
        {
            X = _reader.ReadSingle(),
            Y = _reader.ReadSingle(),
            Z = _reader.ReadSingle(),
            W = _reader.ReadSingle()
        };

        public Matrix4 ReadMatrix4()
        {
            var row0 = ReadVector4();
            var row1 = ReadVector4();
            var row2 = ReadVector4();
            var row3 = ReadVector4();

            return Matrix4.FromRows(row0, row1, row2, row3);
        }

        public Color4 ReadColor4() => new()
        {
            R = _reader.ReadSingle(),
            G = _reader.ReadSingle(),
            B = _reader.ReadSingle(),
            A = _reader.ReadSingle()
        };

        public int[] ReadIntArray()
        {
            var length = _reader.ReadInt32();
            var array = new int[length];

            for (var i = 0; i < length; i++)
            {
                array[i] = _reader.ReadInt32();
            }

            return array;
        }

        public string[] ReadStringArray()
        {
            var length = _reader.ReadInt32();
            var array = new string[length];

            for (var i = 0; i < length; i++)
            {
                array[i] = _reader.ReadString();
            }

            return array;
        }

        public Vector3f[] ReadVector3Array()
        {
            var length = _reader.ReadInt32();
            var array = new Vector3f[length];

            for (var i = 0; i < length; i++)
            {
                array[i] = ReadVector3();
            }

            return array;
        }

        public Matrix4[] ReadMatrix4Array()
        {
            var length = _reader.ReadInt32();
            var array = new Matrix4[length];

            for (var i = 0; i < length; i++)
            {
                array[i] = ReadMatrix4();
            }

            return array;
        }

        public T[] ReadDataArray<T>() where T : IGameData, new()
        {
            var length = _reader.ReadInt32();
            var array = new T[length];

            for (var i = 0; i < length; i++)
            {
                array[i] = new T();
                array[i].LoadData(this);
            }

            return array;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _reader.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataReader()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}