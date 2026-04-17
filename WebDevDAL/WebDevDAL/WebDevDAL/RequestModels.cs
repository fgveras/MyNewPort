using System.Runtime.Serialization;

namespace WebDevDAL
{
    public class RequestModels
    {

        public interface IRequestErrorModel
        {
            bool Error { get; set; }
            string ErrorMessage { get; set; }
        }

        [DataContract]
        public abstract class  ReturnModel<T>()
        {

            public virtual T Data {  get; set; }

            [DataMember]
            public virtual bool Error { get; set; }

            [DataMember]
            public virtual string ErrorMessage { get; set; }

            public void Clone(ReturnModel<T> a)
            {
                Data = a.Data;
                Error = a.Error;
                ErrorMessage = a.ErrorMessage;
            }

        }

        [DataContract]
        public class  GenericResponse<T>() : ReturnModel<T>
        {
            [DataMember]
            public override T Data { get; set; }
        }

    }
}
