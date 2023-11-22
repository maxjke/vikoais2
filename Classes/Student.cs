using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace AntrojiProgramavimoPraktika.Classes
{
    public class Student : User
    {
        public Student()
        {
        }

        public Student(string username, string password, string permission) : base(username, password, permission)
        {
        }

        
    }
}
