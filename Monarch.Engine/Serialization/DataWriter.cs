using Monarch.Engine.Maths;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace SpiceEngine.Core.Serialization
{
    public class DataWriter : IDataWriter, IDisposable
    {
        private readonly BinaryWriter _writer;
        private bool _disposedValue;

        public DataWriter(BinaryWriter writer) => _writer = writer;

        public void WriteShort(short value) => _writer.Write(value);
        public void WriteInt(int value) => _writer.Write(value);
        public void WriteLong(long value) => _writer.Write(value);

        public void WriteUShort(ushort value) => _writer.Write(value);
        public void WriteUInt(uint value) => _writer.Write(value);
        public void WriteULong(ulong value) => _writer.Write(value);

        public void WriteSingle(float value) => _writer.Write(value);
        public void WriteDouble(double value) => _writer.Write(value);

        public void WriteChar(char value) => _writer.Write(value);
        public void WriteString(string value) => _writer.Write(value);

        public void WriteBoolean(bool value) => _writer.Write(value);
        public void WriteByte(byte value) => _writer.Write(value);
        public void WriteEnum<T>(T value) where T : Enum
        {
            var castValue = Unsafe.As<T, int>(ref value);
            _writer.Write(castValue);
        }

        public void WriteType(Type type) => _writer.Write(type.AssemblyQualifiedName!);

        public void WriteVector2(Vector2f value)
        {
            _writer.Write(value.X);
            _writer.Write(value.Y);
        }

        public void WriteVector3(Vector3f value)
        {
            _writer.Write(value.X);
            _writer.Write(value.Y);
            _writer.Write(value.Z);
        }

        public void WriteVector4(Vector4f value)
        {
            _writer.Write(value.X);
            _writer.Write(value.Y);
            _writer.Write(value.Z);
            _writer.Write(value.W);
        }

        public void WriteQuaternion(Quaternion value)
        {
            _writer.Write(value.X);
            _writer.Write(value.Y);
            _writer.Write(value.Z);
            _writer.Write(value.W);
        }

        public void WriteMatrix4(Matrix4 value)
        {
            WriteVector4(value.Row0);
            WriteVector4(value.Row1);
            WriteVector4(value.Row2);
            WriteVector4(value.Row3);
        }

        public void WriteColor4(Color4 value)
        {
            _writer.Write(value.R);
            _writer.Write(value.G);
            _writer.Write(value.B);
            _writer.Write(value.A);
        }

        public void WriteIntArray(int[] value)
        {
            _writer.Write(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                _writer.Write(value[i]);
            }
        }

        public void WriteStringArray(string[] value)
        {
            _writer.Write(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                _writer.Write(value[i]);
            }
        }

        public void WriteVector3Array(Vector3f[] value)
        {
            _writer.Write(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                WriteVector3(value[i]);
            }
        }

        public void WriteMatrix4Array(Matrix4[] value)
        {
            _writer.Write(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                WriteMatrix4(value[i]);
            }
        }

        public void WriteDataArray<T>(T[] value) where T : IGameData, new()
        {
            _writer.Write(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                value[i].SaveData(this);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _writer.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataWriter()
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