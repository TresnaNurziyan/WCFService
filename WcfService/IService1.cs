using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IService1
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
        // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
        [OperationContract]
        [WebGet(UriTemplate = "users", ResponseFormat = WebMessageFormat.Json)]
        List<User> GetUsersList();

        [OperationContract]
        [WebGet(UriTemplate = "user/{id}", ResponseFormat = WebMessageFormat.Json)]
        User GetUserById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "user/{email}/{pass}", ResponseFormat = WebMessageFormat.Json)]
        bool IsValid(string email, string pass);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "user/add/{name}/{email}/{pass}", ResponseFormat = WebMessageFormat.Json)]
        void AddUser(string name, string email, string pass);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "user/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void UpdateUser(UserComposite user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "user/delete/{id}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteUser(string id);

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserComposite
    {
        private int userId;
        private string userName;
        private string userEmail;
        private string userPass;

        [DataMember(Name = "id")]
        public int Id
        {
            get { return userId; }
            set { userId = value; }
        }
        [DataMember(Name = "name")]
        public string Name
        {
            get { return userName; }
            set { userName = value; }
        }
        [DataMember(Name = "email")]
        public string Email
        {
            get { return userEmail; }
            set { userEmail = value; }
        }
        [DataMember(Name = "password")]
        public string Password
        {
            get { return userPass; }
            set { userPass = value; }
        }

        //bool boolValue = true;
        //string stringValue = "Hello ";

        //[DataMember]
        //public bool BoolValue
        //{
        //    get { return boolValue; }
        //    set { boolValue = value; }
        //}

        //[DataMember]
        //public string StringValue
        //{
        //    get { return stringValue; }
        //    set { stringValue = value; }
        //}
    }
}
