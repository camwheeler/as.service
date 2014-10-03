using System.Collections.Generic;
using Nancy;
using ServiceStack;
using ServiceStack.Text;

namespace AfterSchool
{
    public class UserModule : NancyModule
    {
        public UserModule() : base("/users"){
            var user = new UserImpl();
            Get["/list"] = p => user.GetAll();
            Get["/single/{name}"] = p => user.GetSingle(p.name);
        }
    }

    public interface IUserImpl {
        string GetAll();
        string GetSingle(string name);
    }

    public class UserImpl : IUserImpl
    {
        public string GetAll(){
            return new List<string>{"User1", "User2"}.SerializeToString();
        }

        public string GetSingle(string name){
            return name.SerializeAndFormat();
        }
    }
}