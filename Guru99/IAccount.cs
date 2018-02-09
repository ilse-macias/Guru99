using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99
{
    public interface IAccount
    { 
        //void MyAccountLogin(string email, string password);
        void LogIn(string email, string password);
    }
}
