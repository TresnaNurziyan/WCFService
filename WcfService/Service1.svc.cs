using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<User> GetUsersList()
        {
            using (WCFServiceApplicationEntities entities = new WCFServiceApplicationEntities())
            {
                return entities.User.ToList();
            }
        }
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        public User GetUserById(string id)
        {
            try
            {
                int UserId = Convert.ToInt32(id);

                using (WCFServiceApplicationEntities entities = new WCFServiceApplicationEntities())
                {
                    return entities.User.SingleOrDefault(User => User.id == UserId);
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        public bool IsValid(string em, string ps)
        {
            try
            {
                string UserName = em;
                string UserPass = ps;

                using (WCFServiceApplicationEntities entities = new WCFServiceApplicationEntities())
                {
                    var query = (from c in entities.User
                                 where c.email == em && c.password == ps
                                 select c).Any();
                    return query;
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        public void AddUser(string name, string email, string password)
        {
            using (WCFServiceApplicationEntities entities = new WCFServiceApplicationEntities())
            {
                User book = new User { name = name, email = email, password = password };
                entities.User.Add(book);
                entities.SaveChanges();
            }
        }

        public void UpdateUser(UserComposite usr)
        {
            int UserId = Convert.ToInt32(usr.Id);

            using (WCFServiceApplicationEntities entities = new WCFServiceApplicationEntities())
            {
                User wow = entities.User.SingleOrDefault(b => b.id == UserId);
                wow.name = usr.Name;
                wow.email = usr.Email;
                wow.password = usr.Password;
                entities.SaveChanges();
            }
        }

        public void DeleteUser(string id)
        {
            try
            {
                int UserId = Convert.ToInt32(id);

                using (WCFServiceApplicationEntities entities = new WCFServiceApplicationEntities())
                {
                    User User = entities.User.SingleOrDefault(b => b.id == UserId);
                    entities.User.Remove(User);
                    entities.SaveChanges();
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
