using Nancy;

namespace AfterSchool
{
    public class UserMod : NancyModule
    {
        public UserMod() : base("/user"){
            Get["/hello"] = parameters => "Hello World";
        }
    }
}
