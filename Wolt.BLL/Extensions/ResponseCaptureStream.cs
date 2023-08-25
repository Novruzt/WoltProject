using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.Extensions
{
    public class ResponseCaptureStream : Stream
    {
        private readonly Stream _originalStream;
        private readonly MemoryStream _captureStream;

        public ResponseCaptureStream(Stream originalStream)
        {
            _originalStream = originalStream;
            _captureStream = new MemoryStream();
        }

        public string GetCapturedContent()
        {
            _captureStream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(_captureStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        public override void Flush() => _originalStream.Flush();
        public override int Read(byte[] buffer, int offset, int count) => _originalStream.Read(buffer, offset, count);
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => _captureStream.Write(buffer, offset, count);
    }
}
