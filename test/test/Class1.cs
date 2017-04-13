using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test
{


    public class Session
    {
        public Session(ISession session)
        {
        }

        public string Read(string key)
        {
            return string.Empty;
        }

        public void Write(string key)
        {
        }
    }


    public interface ISession
    {
        string Read(string key);

        void Write(string key);
    }



    public class InProcSession : ISession
    {
        public string Read(string key)
        {
            return string.Empty;
        }

        public void Write(string key)
        {
        }
    }

    public class StateServiceSession : ISession
    {
        public string Read(string key)
        {
            return string.Empty;
        }

        public void Write(string key)
        {
        }
    }


    public class SQLServiceSession : ISession
    {
        public string Read(string key)
        {
            return string.Empty;
        }

        public void Write(string key)
        {
        }
    }

}