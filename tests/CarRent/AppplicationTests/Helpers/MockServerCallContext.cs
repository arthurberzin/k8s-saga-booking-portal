using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTests.Helpers
{
    public class MockServerCallContext : ServerCallContext
    {
        private MockServerCallContext() { }
        public new string Method { get; }
        public new string Host { get; }
        public new string Peer { get; }

        public new AuthContext AuthContext { get; }
        public new Metadata RequestHeaders { get; }
        public new CancellationToken CancellationToken { get; }

        protected override string MethodCore => throw new NotImplementedException();

        protected override string HostCore => throw new NotImplementedException();

        protected override string PeerCore => throw new NotImplementedException();

        protected override DateTime DeadlineCore => throw new NotImplementedException();

        protected override Metadata RequestHeadersCore => throw new NotImplementedException();

        protected override CancellationToken CancellationTokenCore => throw new NotImplementedException();

        protected override Metadata ResponseTrailersCore => throw new NotImplementedException();

        protected override Status StatusCore { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        protected override WriteOptions? WriteOptionsCore { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override AuthContext AuthContextCore => throw new NotImplementedException();

        internal static object Create()
        {
            return new MockServerCallContext();
        }

        protected override ContextPropagationToken CreatePropagationTokenCore(ContextPropagationOptions? options)
        {
            throw new NotImplementedException();
        }

        protected override Task WriteResponseHeadersAsyncCore(Metadata responseHeaders)
        {
            throw new NotImplementedException();
        }
    }
}
