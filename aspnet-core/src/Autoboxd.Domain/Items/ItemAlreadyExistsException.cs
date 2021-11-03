using Volo.Abp;

namespace Autoboxd.Items
{
    public class ItemAlreadyExistsException : BusinessException
    {
        public ItemAlreadyExistsException(string name)
            : base(AutoboxdDomainErrorCodes.ItemAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
