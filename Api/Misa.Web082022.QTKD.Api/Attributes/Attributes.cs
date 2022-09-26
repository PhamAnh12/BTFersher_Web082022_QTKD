namespace Misa.Web082022.QTKD.API.Attributes
{
    /// <summary>
    /// Attributes dùng để xác định 1 prop là khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimarykeyAttribute : Attribute
    {

    }
    /// <summary>
    /// Atribute xác định prop không được để trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        public string Msg;

        public IsNotNullOrEmptyAttribute(string msg)
        {
            this.Msg = msg;
        }
    }

}
