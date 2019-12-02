using System;
using Moq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AceBookTests
{
    public class MockSession : ISession
    {
        Dictionary<string, object> sessionStorage = new Dictionary<string, object>();
        public object this[string name]
        {
            get { return sessionStorage[name]; }
            set { sessionStorage[name] = value; }
        }
        string ISession.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        bool ISession.IsAvailable
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        IEnumerable<string> ISession.Keys
        {
            get { return sessionStorage.Keys; }
        }
        void ISession.Clear()
        {
            sessionStorage.Clear();
        }
        public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
        public Task LoadAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
        void ISession.Remove(string key)
        {
            sessionStorage.Remove(key);
        }
        void ISession.Set(string key, byte[] value)
        {
            sessionStorage[key] = value;
        }
        bool ISession.TryGetValue(string key, out byte[] value)
        {
            if (sessionStorage[key] != null)
            {
                value = Encoding.ASCII.GetBytes(sessionStorage[key].ToString());
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
    }
}
